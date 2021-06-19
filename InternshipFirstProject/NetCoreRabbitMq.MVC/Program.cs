using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipFirstProject.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IdentityModelEventSource.ShowPII = true;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:6000");
                });
    }
}
