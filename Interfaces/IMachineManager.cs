using _ProyectoFinal_Johanny_Vivas_Arias.Models;
using System.Collections.Generic;

namespace _ProyectoFinal_Johanny_Vivas_Arias.Interfaces
{
    public interface IMachineManager
    {
        List<DamageLog> RunSimulation(List<ContinuosProdEmulate> emulateData);
        List<Machine> GetMachines();
        Machine GetMachinById(int id);
        bool AddMachine(Machine machine);
        bool DeleteMachine(int id);
        bool EditMachine(Machine machine);
        List<ContinuosProdEmulate> GetAllEmulateData();
        bool EditEmulateMachine(ContinuosProdEmulate data);
        ContinuosProdEmulate GetEmulateDataById(int id);
    }
}
