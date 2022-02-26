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
            //int HorasSemanaM1 = emulateData[0].dailyHours * emulateData[0].weeklyDays;
            //int SemanasMesM1 = emulateData[0].Months * 4;
            //int TotalHorasM1 = HorasSemanaM1 * SemanasMesM1;
            //int MinutesM1 = TotalHorasM1 * 60;

            //int HorasSemanaM2 = emulateData[1].dailyHours * emulateData[1].weeklyDays;
            //int SemanasMesM2 = emulateData[1].Months * 4;
            //int TotalHorasM2 = HorasSemanaM2 * SemanasMesM2;
            //int MinutesM2 = TotalHorasM2 * 60;

            //int segundos = MinutesM1 > MinutesM2 ? MinutesM1 : MinutesM2;

            int MinutesM1 = (((emulateData[0].dailyHours * emulateData[0].weeklyDays) * 4) * emulateData[0].Months) * 60;
            int MinutesM2 = (((emulateData[1].dailyHours * emulateData[1].weeklyDays) * 4) * emulateData[1].Months) * 60;
            int minutes = MinutesM1 > MinutesM2 ? MinutesM1 : MinutesM2;

            int count = 0;

            int dayM1 = 1;
            int hoursM1 = 1;
            int monthM1 = 1;

            int dayM2 = 1;
            int hoursM2 = 1;
            int monthM2 = 1;

            int c = 0;
            DamageLog log = new DamageLog();
            for (int i = 0; i <= minutes; i++)
            {
                count++;

                if (count == 60)
                {
                    c++;
                    count = 0;
                    //hoursM1++;
                    //hoursM2++;


                    if (i<= MinutesM1)
                    {
                        hoursM1++;
                  
                        if (hoursM1 == emulateData[0].dailyHours)
                        {
                            hoursM1 = 1;
                            dayM1++;

                            if (dayM1 == (emulateData[0].weeklyDays * 4))
                            {
                                dayM1 = 1;
                                monthM1++;
                            }
                        }
                        emulateData[0].totalHours++;
                        if (emulateData[0].machine.status)
                        {
                            emulateData[0].totalProducts = emulateData[0].totalProducts + emulateData[0].machine.productsPerHour;
                            Random random = new Random();
                            string number = random.NextDouble().ToString("0.0");
                            if (number == emulateData[0].machine.failProbability)
                            {
                                emulateData[0].machine.status = false;


                                 log = new DamageLog
                                {
                                    DamageMachine = emulateData[0].machine,
                                    MachineInProd = emulateData[1].machine,
                                    month = monthM1,
                                    day = dayM1,
                                    hour = hoursM1,
                                    buidProdInFailTime = emulateData[0].totalProducts,
                                    wingrossInFailTime = emulateData[0].totalProducts * emulateData[0].product.productPrice,
                                    realWinInFailTime = (emulateData[0].totalProducts * emulateData[0].product.productPrice) - (emulateData[0].hourCost * emulateData[0].totalHours),
                                    monthRepare = 0,// monthM1,
                                    dayRepare = 0,//hoursM1 + emulateData[0].machine.timeToFix > emulateData[0].dailyHours ? dayM1 + 1 : dayM1,
                                    hourRepare = 0, // hoursM1 + emulateData[0].machine.timeToFix,
                                    buidProdOtherMachine = emulateData[1].totalProducts,
                                    wingrossOtherMachine = emulateData[1].totalProducts * emulateData[1].product.productPrice,
                                    realWinOtherMachine = (emulateData[1].totalProducts * emulateData[1].product.productPrice) - (emulateData[1].hourCost * emulateData[1].totalHours)

                                };
                                //logs.Add(log);
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

                                //ADD LOG M1
                                log.monthRepare = monthM1;
                                log.dayRepare = dayM1;
                                log.hourRepare = hoursM1;
                                logs.Add(log);
                            }
                        }
                    }

                    if (i <= MinutesM2)
                    {
                        hoursM2++;
                        if (hoursM2 == emulateData[1].dailyHours)
                        {
                            hoursM2 = 1;
                            dayM2++;

                            if (dayM2 == (emulateData[1].weeklyDays * 4))
                            {
                                dayM2 = 1;
                                monthM2++;
                            }
                        }
                        emulateData[1].totalHours++;
                        if (emulateData[1].machine.status)
                        {
                            emulateData[1].totalProducts = emulateData[0].totalProducts + emulateData[0].machine.productsPerHour;
                            Random random = new Random();
                            string number = random.NextDouble().ToString("0.0");
                            if (number == emulateData[1].machine.failProbability)
                            {
                                emulateData[1].machine.status = false;
                                //DamageLog log = new DamageLog
                                 log = new DamageLog
                                {
                                    DamageMachine = emulateData[1].machine,
                                    MachineInProd = emulateData[0].machine,
                                    month = monthM2,
                                    day = dayM2  ,
                                    hour = hoursM2 ,
                                    buidProdInFailTime = emulateData[1].totalProducts,
                                    wingrossInFailTime = emulateData[1].totalProducts * emulateData[1].product.productPrice,
                                    realWinInFailTime = (emulateData[1].totalProducts * emulateData[1].product.productPrice) - (emulateData[1].hourCost * emulateData[1].totalHours),
                                    monthRepare = 0,//monthM2,
                                    dayRepare = 0,//dayM2,
                                    hourRepare = 0,//hoursM2 + emulateData[0].machine.timeToFix,
                                    buidProdOtherMachine = emulateData[0].totalProducts,
                                    wingrossOtherMachine = emulateData[0].totalProducts * emulateData[0].product.productPrice,
                                    realWinOtherMachine = (emulateData[0].totalProducts * emulateData[0].product.productPrice) - (emulateData[0].hourCost * emulateData[0].totalHours),
                                };
                                //logs.Add(log);
                            }
                          
                        }
                        else
                        {
                            emulateData[1].timeToRepare++;
                            emulateData[1].TotalTimeInRepare++;
                            if (emulateData[1].timeToRepare == emulateData[1].machine.timeToFix)
                            {
                                emulateData[1].machine.status = true;
                                emulateData[1].machine.status = true;
                                emulateData[1].timeToRepare = 0;
                                
                                //ADD LOG M2
                                log.monthRepare = monthM2;
                                log.dayRepare = dayM2;
                                log.hourRepare = hoursM2;
                                logs.Add(log);
                            }
                        }
                    }
                }     
            }


            foreach (var item in emulateData)
            {
                item.wingross= (item.product.productPrice * item.totalProducts);
                item.realWin = item.wingross - item.hourCost * item.totalHours;
                item.totalHours = 0;
                item.timeToRepare = 0;
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
