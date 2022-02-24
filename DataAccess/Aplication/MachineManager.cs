using _ProyectoFinal_Johanny_Vivas_Arias.Interfaces;
using _ProyectoFinal_Johanny_Vivas_Arias.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace _ProyectoFinal_Johanny_Vivas_Arias.DataAccess.Aplication
{
    public class MachineManager : IMachineManager
    {
        private readonly IMachineRepository _repository;
        public MachineManager(IMachineRepository repository)
        {
            _repository = repository;
            //do
            //{
            //     number = random.NextDouble().ToString("0.0");
            //     result = float.Parse(number);
            //    if (number == "2,0")
            //    {
            //        int i = 0;
            //    }
            //} while (result != 0.1);
        }

        public void RunSimulation(ContinuosProdEmulate emulateData)
        {
            List<Machine> machines = _repository.GetAllMachine();
            Random random = new Random();
            string number = random.NextDouble().ToString("0.0");
       
            ProduceProduct(emulateData);

        }

        public bool ProduceProduct(ContinuosProdEmulate data)
        {
            //machine.continuosProdEmulate.Months = machine.continuosProdEmulate.weeklyDays / 4;
            //machine.continuosProdEmulate.days = 0;
            //machine.continuosProdEmulate.hours = 0;

            //(CALCULO HORAS SEMANA) 8h * 6d = 48 Horas semanal
            //(CALCULO SEMANAS MES)  6 mes * 4 semanas del mes   = 24 semanas en 6 meses;
            //(CALCULO HORAS DE LOS MESES) 24sem * 48 horas semanal = 1152 horas

            //MESES = 6
            //DIAS = 15
            //HORAS =100


            int HorasSemana = data.dailyHours * data.weeklyDays;
            int SemanasMes = data.Months * 4;
            int TotalHoras = HorasSemana * SemanasMes;

            for (int i = 0; i <= TotalHoras; i++)
            {

            }

            return true;
        }

        public List<Machine> GetMachines()
        {
            return _repository.GetAllMachine();
        }

        public Machine GetMachinById(int id)
        {
            return _repository.GetMachinById(id);
        }
    }
}
