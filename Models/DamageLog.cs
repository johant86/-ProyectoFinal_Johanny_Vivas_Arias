namespace _ProyectoFinal_Johanny_Vivas_Arias.Models
{
    public class DamageLog
    {
        public int id { set; get; }
        public virtual Machine DamageMachine { set; get; }
        public virtual Machine MachineInProd { set; get; }
        public int month { set; get; }
        public int day { set; get; }
        public int hour { set; get; }
        public int buidProdInFailTime { set; get; }
        public float wingrossInFailTime { set; get; }
        public float realWinInFailTime { set; get; }
        public int monthRepare { set; get; }
        public int dayRepare { set; get; }
        public int hourRepare { set; get; }
        public int buidProdOtherMachine { set; get; }
        public float wingrossOtherMachine { set; get; }
        public float realWinOtherMachine { set; get; }
    }
}
