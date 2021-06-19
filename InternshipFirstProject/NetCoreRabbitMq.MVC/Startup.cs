using InternshipFirstProject.RabbitMQ.Config;
using InternshipFirstProject.RabbitMQ.Interfaces;
using InternshipFirstProject.RabbitMQ.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace InternshipFirstProject.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            services.Configure<RabbitMqConnectionConfiguration>(serviceClientSettingsConfig);
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
            });
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.Authority = "http://localhost:5001";
                o.Audience = "portal-resource";
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = false,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = false,
                    ValidateLifetime = true,
                };

                //options.Audience = "portal-resource"; //api resource
                //options.TokenValidationParameters.ValidIssuer = "http://localhost:5001";
            });
            /*
             
             options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = (context) =>
                    {
                        var name = context.Principal.Identity.Name;
                        if (string.IsNullOrEmpty(name))
                        {
                            context.Fail("Unauth. Try again");
                        }
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                        var tokenHandler = new JwtSecurityTokenHandler();
                        try
                        {
                            tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                            {
                                ValidateActor = false,
                                ValidateAudience = false,
                                ValidateIssuer = false,
                                ValidateIssuerSigningKey = false,
                                ValidateLifetime = false,
                                ValidateTokenReplay = false,
                            }, out SecurityToken validatedToken);
                        }
                        catch
                        {
                            Console.WriteLine("aaaa");
                        }
                        context.Token = accessToken;
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = (context) =>
                    {
                        var ct = context;
                        return Task.CompletedTask;
                    }
                };
             */
            services.AddAuthorization();

            services.AddTransient<IRabbitHelper, RabbitHelper>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
