using _ProyectoFinal_Johanny_Vivas_Arias.DataAccess.Contexts;
using _ProyectoFinal_Johanny_Vivas_Arias.Interfaces;
using _ProyectoFinal_Johanny_Vivas_Arias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _ProyectoFinal_Johanny_Vivas_Arias.DataAccess.Repositories
{
    public class DbMachineRepository : IMachineRepository
    {
        private readonly SimulatorDataContext _context;

        public DbMachineRepository(SimulatorDataContext context)
        {
            _context = context;
        }

        public List<Machine> GetAllMachine()
        {
            return _context.tbMachine.ToList();
            //{
            //    new Machine{
            //        id = 1,
            //        productsPerHour = 100,
            //        failProbability = "1,0" ,
            //        status = true,
            //        timeToFix = 3,
            //        continuosProdEmulate = new ContinuosProdEmulate
            //        {
            //            dailyHours = 8,
            //            weeklyDays = 6,
            //            product = new Product{ id = 1, name = "Clavos" , productPrice = 5 },
            //            hourCost = 10,
            //            hours = 0,
            //            days = 0 ,
            //            Months = 6
            //        }
            //    },
            //    new Machine
            //    {
            //        id = 2,
            //        productsPerHour = 100,
            //        failProbability = "0,7" ,
            //        status = true,
            //        timeToFix = 3,
            //        continuosProdEmulate = new ContinuosProdEmulate
            //        {
            //            dailyHours = 12,
            //            weeklyDays = 6,
            //            product =  new Product{ id = 2, name = "Tornillos" , productPrice = 5 },
            //            hourCost = 15,
            //            hours = 0,
            //            days = 0 ,
            //            Months = 4
            //        }

            //    },
            //};
        }

        public Machine GetMachinById(int id)
        {
            return _context.tbMachine.Where(x=>x.id == id).FirstOrDefault();
        }
    }
}
