using _ProyectoFinal_Johanny_Vivas_Arias.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _ProyectoFinal_Johanny_Vivas_Arias.DataAccess.Contexts
{
    public class SimulatorDataContext : DbContext
    {
        public SimulatorDataContext(DbContextOptions<SimulatorDataContext> options) : base(options)
        { }
        public DbSet<Product> tbProducts { get; set; }
        public DbSet<Machine> tbMachine { get; set; }
        public DbSet<ContinuosProdEmulate> tbContinuosProdEmulate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("kdf");
            this.CreateProductosData(modelBuilder);
            this.CreateMachinesData(modelBuilder);
            this.CreateContinuosEmulateData(modelBuilder);
        }

        private void CreateProductosData(ModelBuilder builder)
        {

            List<Product> products = new List<Product>()
            {
                new Product{ id = 1, name = "Clavos" , productPrice = 5 },
                new Product{ id = 2, name = "Tornillos" , productPrice = 5 },
            };

            builder.Entity<Product>().HasData(products);
        }
        private void CreateMachinesData(ModelBuilder builder)
        {

            List<Machine> Machines = new List<Machine>()
            {
                new Machine{
                    id = 1,
                    productsPerHour = 100,
                    failProbability = "1,0" ,
                    status = true,
                    timeToFix = 3,

                },
                new Machine
                {
                    id = 2,
                    productsPerHour = 100,
                    failProbability = "0,7" ,
                    status = true,
                    timeToFix = 3,

                },
            };

            builder.Entity<Machine>().HasData(Machines);
        }
        private void CreateContinuosEmulateData(ModelBuilder builder)
        {

            List<ContinuosProdEmulate> continuosProdEmulates = new List<ContinuosProdEmulate>()
            {
                 new ContinuosProdEmulate
                {
                    id= 1,
                    dailyHours = 8,
                    weeklyDays = 6,
                    //product = new Product { id = 4 ,name = "test2"},
                    //machine = new Machine{id = 3 ,name = "test1"},
                    hourCost = 10,
                    hours = 0,
                    days = 0,
                    Months = 6
                },
                new ContinuosProdEmulate
                    {
                        id = 2,
                        dailyHours = 12,
                        weeklyDays = 6,
                        //product =  new Product{ id = 2},
                        //machine = new Machine{id =1},
                        hourCost = 15,
                        hours = 0,
                        days = 0 ,
                        Months = 4
                    }
            };

            builder.Entity<ContinuosProdEmulate>().HasData(continuosProdEmulates);

        }
    }
}
