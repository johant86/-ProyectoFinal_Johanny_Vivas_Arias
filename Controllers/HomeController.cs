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
            Machine machine = _Aplication.GetMachines()[0];
            return View(machine);
        }

        public IActionResult MachineTwo()
        {
            Machine machine = _Aplication.GetMachines()[1];
            return View(machine);
        }

        public IActionResult ViewCreateMachine()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMachine(Machine machine)
        {
               _Aplication.AddMachine(machine);
               return RedirectToAction("MachineOne");
        }

        public IActionResult DeleteMachine(int id)
        {
            _Aplication.DeleteMachine(id);
            return View();
        }

        public IActionResult ViewEditMachine(int id)
        {
            Machine machine = _Aplication.GetMachinById(id);
            return View(machine);
        }
        public IActionResult EditMachine(Machine machine)
        {
            _Aplication.EditMachine(machine);
            return RedirectToAction(machine.id==1 ? "MachineOne" : "MachineTwo");
        }

        public IActionResult EmulatorView()
        {
            List<ContinuosProdEmulate> data = _Aplication.GetAllEmulateData();
            return View(data);
        }

        public IActionResult CreateEmulateConfiguration()
        {
            return View();
        }

        public IActionResult EditEmulateConfiguration(int id)
        {
           ContinuosProdEmulate data =  _Aplication.GetEmulateDataById(id);

            return View(data);
        }

        public IActionResult SaveEditEmulateConfiguration(ContinuosProdEmulate data)
        {
            bool value = _Aplication.EditEmulateMachine(data);

            return RedirectToAction("EmulatorView");
        }

        public IActionResult AddEmulateConfiguration(ContinuosProdEmulate cofig)
        {
            return RedirectToAction("EmulatorView");
        }

        public IActionResult ExecuteSimulation()
        {
            List<ContinuosProdEmulate> data = _Aplication.GetAllEmulateData();

            List<DamageLog> logs=  _Aplication.RunSimulation(data);
        

            return View(logs);
        }

        public IActionResult SimulationResult()
        {    
            List<ContinuosProdEmulate> data = _Aplication.GetAllEmulateData();
            return View(data);
        }

    }
}
