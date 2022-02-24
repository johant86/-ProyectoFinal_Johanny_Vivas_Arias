using System.ComponentModel.DataAnnotations;

namespace _ProyectoFinal_Johanny_Vivas_Arias.Models
{
    public class Product
    {
        [Key]
        public int id { set; get; }
        public string name { set; get; }
        public float productPrice { set; get; }
    }
}
