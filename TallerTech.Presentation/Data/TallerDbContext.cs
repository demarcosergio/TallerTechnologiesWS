using Microsoft.EntityFrameworkCore;
using TallerTech.Presentation.Data.Entities;

namespace TallerTech.Presentation.Data
{
    public class TallerDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public TallerDbContext(DbContextOptions<TallerDbContext> options) : base(options)
        {
            if (this.Database.GetPendingMigrations().Any())
            {
                this.Database.Migrate();
            }

            if (!Cars.Any())
            {
                this.Set<Car>().AddRange(
                    new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995, Guess = 0, Guessed = false },
                    new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995, Guess = 0, Guessed = false },
                    new Car { Id = 3, Make = "Porsche", Model = "911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000, Guess = 0, Guessed = false },
                    new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995, Guess = 0, Guessed = false },
                    new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995, Guess = 0, Guessed = false }
                );

                this.SaveChanges();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
        .HasKey(c => c.PersonID);
            
            modelBuilder.Entity<OrderDetails>()
        .HasKey(c => c.OrderID);
        }
    }
}