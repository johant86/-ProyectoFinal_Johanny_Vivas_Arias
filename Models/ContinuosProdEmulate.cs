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
        public int totalProducts { set; get; }
        public int TotalTimeInRepare { set; get; }
        public int timeToRepare { set; get; }
        public float wingross { set; get; }
        public float realWin { set; get; }
        public int totalHours { set; get; }

    }
}
