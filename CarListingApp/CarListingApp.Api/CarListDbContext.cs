using Microsoft.EntityFrameworkCore;

namespace CarListingApp.Api
{
    public class CarListDbContext:DbContext
    {
        public CarListDbContext(DbContextOptions<CarListDbContext> options):base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasData(

                 new Car
                 {
                     Id = 1,
                     Make = "Honda",
                     Model = "Fit",
                     Vin = "123"
                 },
                 new Car
                 {
                     Id = 2,
                     Make = "Toyota",
                     Model = "Prade",
                     Vin = "123"
                 },
                  new Car
                  {
                      Id = 3,
                      Make = "Honda",
                      Model = "Civic",
                      Vin = "123"
                  },
                 new Car
                 {
                     Id = 4,
                     Make = "Audi",
                     Model = "AS",
                     Vin = "123"
                 },
                  new Car
                  {
                      Id = 5,
                      Make = "BMw",
                      Model = "M1",
                      Vin = "123"
                  },
                   new Car
                   {
                       Id = 6,
                       Make = "Nissan",
                       Model = "Note",
                       Vin = "123"
                   },
                    new Car
                    {
                        Id = 7,
                        Make = "Ferrari",
                        Model = "Spider",
                        Vin = "123"
                    });
        }
    }
}