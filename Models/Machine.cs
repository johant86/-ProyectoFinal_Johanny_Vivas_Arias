using System.ComponentModel.DataAnnotations;

namespace _ProyectoFinal_Johanny_Vivas_Arias.Models
{
    public class Machine
    {
        [Key]
        public int id { set; get; }
        public string name { set; get; }
        public string failProbability { set; get; }
        public int productsPerHour { set; get; }
        public int timeToFix { set; get; }
        public bool status { set; get; }
        //public virtual ContinuosProdEmulate continuosProdEmulate { set; get; }
    }

}
