using _ProyectoFinal_Johanny_Vivas_Arias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _ProyectoFinal_Johanny_Vivas_Arias.Interfaces
{
    public interface IMachineManager
    {
        void RunSimulation(ContinuosProdEmulate emulateData);
        List<Machine> GetMachines();
        Machine GetMachinById(int id);
    }
}
