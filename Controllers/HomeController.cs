using _ProyectoFinal_Johanny_Vivas_Arias.DataAccess.Aplication;
using _ProyectoFinal_Johanny_Vivas_Arias.Interfaces;
using _ProyectoFinal_Johanny_Vivas_Arias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _ProyectoFinal_Johanny_Vivas_Arias.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMachineManager _Aplication;

        public HomeController(ILogger<HomeController> logger, IMachineManager app)
        {
            _logger = logger;
            _Aplication = app;
        }

        public IActionResult Index()
        {
            ContinuosProdEmulate emulate = new ContinuosProdEmulate()
            {
                id = 1,
                dailyHours = 8,
                weeklyDays = 6,
                product = new Product 
                { 
                    id = 1, 
                    name = "test2" 
                },
                machine = new Machine
                {
                    id = 1,
                    productsPerHour = 100,
                    failProbability = "1,0",
                    status = true,
                    timeToFix = 3,

                },
                hourCost = 10,
                hours = 0,
                days = 0,
                Months = 6
            };
            _Aplication.RunSimulation(emulate);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Configuration()
        {
            return View();
        }

        public IActionResult MachineOne()
        {
            Machine machine = _Aplication.GetMachinById(1);


            return View(machine);
        }

        public IActionResult MachineTwo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMachine(Machine machine)
        {

            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
