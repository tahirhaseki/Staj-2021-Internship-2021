using InternshipFirstProject.MVC.Models;
using InternshipFirstProject.RabbitMQ.Config;
using InternshipFirstProject.RabbitMQ.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipFirstProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRabbitHelper _rabbitHelper;

        public HomeController(ILogger<HomeController> logger,IRabbitHelper rabbitHelper)
        {
            _logger = logger;
            _rabbitHelper = rabbitHelper;
        }

        public IActionResult Index()
        {
            /*_rabbitHelper.SendMessage<string>("First Message", "direct"
                                             , new RabbitMqExchangeConfiguration("direct-exchange","direct")
                                             , new RabbitMqQueueConfiguration("Orders","direct-exchange","order")
                                             , new RabbitMqMessageConfiguration("direct-exchange","order"));*/
            return View();
        }

        public IActionResult Privacy()
        {
            _rabbitHelper.SendMessage<string>("Test Message", "fanout"
                                 , new RabbitMqExchangeConfiguration("fanout-exchange", "fanout")
                                 , new RabbitMqQueueConfiguration("Shippings", "fanout-exchange", "shipping")
                                 , new RabbitMqMessageConfiguration("fanout-exchange", "shipping"));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
