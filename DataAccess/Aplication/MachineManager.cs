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
        }

        public List<DamageLog> RunSimulation(List<ContinuosProdEmulate> emulateData)
        {
            //List<Machine> machines = _repository.GetAllMachine();
            //Random random = new Random();
            //string number = random.NextDouble().ToString("0.0");

            //machine.continuosProdEmulate.Months = machine.continuosProdEmulate.weeklyDays / 4;
            //machine.continuosProdEmulate.days = 0;
            //machine.continuosProdEmulate.hours = 0;

            //(CALCULO HORAS SEMANA) 8h * 6d = 48 Horas semanal
            //(CALCULO SEMANAS MES)  6 mes * 4 semanas del mes   = 24 semanas en 6 meses;
            //(CALCULO HORAS DE LOS MESES) 24sem * 48 horas semanal = 1152 horas

            //MESES = 6
            //DIAS = 15
            //HORAS =100

            List<DamageLog> logs = new List<DamageLog>();
            int HorasSemanaM1 = emulateData[0].dailyHours * emulateData[0].weeklyDays;
            int SemanasMesM1 = emulateData[0].Months * 4;
            int TotalHorasM1 = HorasSemanaM1 * SemanasMesM1;
            int segundosM1 = TotalHorasM1 * 60;

            int HorasSemanaM2 = emulateData[1].dailyHours * emulateData[1].weeklyDays;
            int SemanasMesM2 = emulateData[1].Months * 4;
            int TotalHorasM2 = HorasSemanaM2 * SemanasMesM2;
            int segundosM2 = TotalHorasM2 * 60;

            int segundos = segundosM1 > segundosM2 ? segundosM1 : segundosM2;

            int count = 0;

            for (int i = 0; i <= segundos; i++)
            {
                count++;

                if (count == 60)
                {
                    
                    count = 0;
                    if (i<= segundosM1)
                    {
                        emulateData[0].totalHours++;
                        if (emulateData[0].machine.status)
                        {
                            emulateData[0].totalProducts = emulateData[0].totalProducts + emulateData[0].machine.productsPerHour;
                            Random random = new Random();
                            string number = random.NextDouble().ToString("0.0");
                            if (number == emulateData[0].machine.failProbability)
                            {
                                emulateData[0].machine.status = false;
                                DamageLog log = new DamageLog
                                {
                                    idMachine = emulateData[0].machine.id,
                                    month =  (i / ((HorasSemanaM1 * 4) * 60)) < 0 ? 1 : (i / ((HorasSemanaM1 * 4) * 60)),
                                    day = 4,
                                    hour = 3 ,
                                    buidProdInFailTime = emulateData[0].totalProducts,
                                    wingrossInFailTime = emulateData[0].totalProducts * emulateData[0].product.productPrice,
                                    realWinInFailTime = emulateData[0].totalProducts * emulateData[0].product.productPrice,
                                    monthRepare = 1 ,
                                    dayRepare = 2,
                                    hourRepare = 2,
                                    buidProdOtherMachine = emulateData[1].totalProducts,
                                    wingrossOtherMachine = emulateData[1].totalProducts * emulateData[1].product.productPrice,
                                    realWinOtherMachine = emulateData[1].totalProducts * emulateData[1].product.productPrice

                                };
                                logs.Add(log);
                            }

                        }
                        else
                        {
                            emulateData[0].timeToRepare++;
                            emulateData[0].TotalTimeInRepare++;
                            if (emulateData[0].timeToRepare == emulateData[0].machine.timeToFix)
                            {
                                emulateData[0].machine.status = true;
                                emulateData[0].timeToRepare = 0;
                            }
                        }
                    }

                    if (i <= segundosM2)
                    {
                        emulateData[1].totalHours++;
                        if (emulateData[1].machine.status)
                        {
                            emulateData[1].totalProducts = emulateData[0].totalProducts + emulateData[0].machine.productsPerHour;
                            Random random = new Random();
                            string number = random.NextDouble().ToString("0.0");
                            if (number == emulateData[1].machine.failProbability)
                            {
                                emulateData[1].machine.status = false;
                                DamageLog log = new DamageLog
                                {
                                    idMachine = emulateData[1].machine.id,
                                    month = (i / ((HorasSemanaM1 * 4) * 60)) < 0 ? 1 : (i / ((HorasSemanaM1 * 4) * 60)),
                                    day = 4,
                                    hour = 3,
                                    buidProdInFailTime = emulateData[1].totalProducts,
                                    wingrossInFailTime = emulateData[1].totalProducts * emulateData[1].product.productPrice,
                                    realWinInFailTime = emulateData[1].totalProducts * emulateData[1].product.productPrice,
                                    monthRepare = 1,
                                    dayRepare = 2,
                                    hourRepare = 2,
                                    buidProdOtherMachine = emulateData[0].totalProducts,
                                    wingrossOtherMachine = emulateData[0].totalProducts * emulateData[0].product.productPrice,
                                    realWinOtherMachine = emulateData[0].totalProducts * emulateData[0].product.productPrice
                                };
                                logs.Add(log);
                            }
                          
                        }
                        else
                        {
                            emulateData[1].timeToRepare++;
                            emulateData[1].TotalTimeInRepare++;
                            if (emulateData[1].timeToRepare == emulateData[1].machine.timeToFix)
                            {
                                emulateData[1].machine.status = true;
                                emulateData[1].timeToRepare = 0;
                            }
                        }
                    }
                }     
            }


            foreach (var item in emulateData)
            {
                item.wingross= (item.product.productPrice * item.totalProducts);
                item.realWin = item.wingross - item.hourCost * item.totalHours;
                _repository.EditContinuosProdEmulate(item);
            }

            return logs;

        }

        //public ContinuosProdEmulate ProduceProduct(ContinuosProdEmulate data)
        //{

        //}

        public List<Machine> GetMachines()
        {
            return _repository.GetAllMachine();
        }

        public Machine GetMachinById(int id)
        {
            return _repository.GetMachinById(id);
        }

        public bool AddMachine(Machine machine)
        {
            return _repository.AddMachine(machine);
        }

        public bool DeleteMachine(int id)
        {
            return _repository.DeleteMachine(id);
        }

        public bool EditMachine(Machine machine)
        {
            return _repository.EditMachine(machine);
        }

        public List<ContinuosProdEmulate> GetAllEmulateData()
        {
            return _repository.GetAllEmulateData();
        }

        public bool EditEmulateMachine(ContinuosProdEmulate data)
        {
            return _repository.EditEmulateMachine(data);

        }

        public ContinuosProdEmulate GetEmulateDataById(int id)
        {
            return _repository.GetEmulateDataById(id);

        }
    }
}
