using _ProyectoFinal_Johanny_Vivas_Arias.DataAccess.Contexts;
using _ProyectoFinal_Johanny_Vivas_Arias.Interfaces;
using _ProyectoFinal_Johanny_Vivas_Arias.Models;
using Microsoft.EntityFrameworkCore;
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

        public bool AddMachine(Machine machine)
        {
            if (machine != null)
            {
                _context.tbMachine.Add(machine);
                _context.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public bool DeleteMachine(int id)
        {
            try
            {
                Machine record = _context.tbMachine.Where(x => x.id == id).FirstOrDefault();
                if (record != null)
                {
                    _context.tbMachine.Attach(record);
                    _context.tbMachine.Remove(record);
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

 

        }

        public bool EditContinuosProdEmulate(ContinuosProdEmulate data)
        {
            var finder = _context.tbContinuosProdEmulate.AsNoTracking().FirstOrDefault(x => x.id == data.id);

            if (finder != null)
            {

                _context.tbContinuosProdEmulate.Update(data);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool EditEmulateMachine(ContinuosProdEmulate data)
        {
            var finder = _context.tbContinuosProdEmulate.AsNoTracking().FirstOrDefault(x => x.id == data.id);

            if (finder != null)
            {

                _context.tbContinuosProdEmulate.Update(data);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool EditMachine(Machine machine)
        {
            var finder = _context.tbMachine.AsNoTracking().FirstOrDefault(x => x.id == machine.id);

            if (finder != null)
            {

                _context.tbMachine.Update(machine);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        
    }

        public List<ContinuosProdEmulate> GetAllEmulateData()
        {
            return _context.tbContinuosProdEmulate.Select(x => new ContinuosProdEmulate
            {
                id =x.id,
                dailyHours = x.dailyHours,
                weeklyDays = x.weeklyDays,
                hourCost = x.hourCost,
                Months = x.Months,
                days = x.days,
                hours = x.hours,
                realWin = x.realWin,
                wingross = x.wingross,
                totalHours = x.totalHours,
                totalProducts=x.totalProducts,
                machine = _context.tbMachine.Where(a=>a.id == x.machine.id).FirstOrDefault(),
                product = _context.tbProducts.Where(b => b.id == x.product.id).FirstOrDefault(),

            }).ToList();
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

        public ContinuosProdEmulate GetEmulateDataById(int id)
        {
            return _context.tbContinuosProdEmulate.Where(x => x.id == id).FirstOrDefault();
        }

        public Machine GetMachinById(int id)
        {
            return _context.tbMachine.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
