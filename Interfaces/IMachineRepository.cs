using _ProyectoFinal_Johanny_Vivas_Arias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _ProyectoFinal_Johanny_Vivas_Arias.Interfaces
{
    public interface IMachineRepository
    {
        List<Machine> GetAllMachine();
        Machine GetMachinById(int id);
        bool AddMachine(Machine machine);
        bool DeleteMachine(int id);
        bool EditMachine(Machine machine);
        List<ContinuosProdEmulate> GetAllEmulateData();
        bool EditEmulateMachine(ContinuosProdEmulate data);

        ContinuosProdEmulate GetEmulateDataById(int id);

        bool EditContinuosProdEmulate(ContinuosProdEmulate data);
    }
}
