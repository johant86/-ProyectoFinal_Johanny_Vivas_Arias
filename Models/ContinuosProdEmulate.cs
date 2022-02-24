using System.ComponentModel.DataAnnotations;

namespace _ProyectoFinal_Johanny_Vivas_Arias.Models
{
    public class ContinuosProdEmulate
    {
        [Key]
        public int id { set; get; }
        public virtual Machine machine { set; get; }
        public virtual Product product { set; get; }
        public int dailyHours { set; get; }
        public int weeklyDays { set; get; }
        public float hourCost { set; get; }
        public int Months { set; get; }
        public int days { set; get; }
        public int hours { set; get; }
    }
}
