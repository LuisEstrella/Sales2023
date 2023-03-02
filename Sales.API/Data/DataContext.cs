using Microsoft.EntityFrameworkCore;
using Sales.Shared.Entities;

namespace Sales.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City>? Cities { get; set; }



        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Este HasIndex es para que no se repitan los datos en paises, ejemplo : no pueden haber 2 paises llamados igual
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<State>().HasIndex("CountryId", "Name").IsUnique(); // Esto es para los nombres no se repitan por pais, ejemplo en antioquia no va a ver mas de un rionegro

            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique(); //Esto es para que la ciudad no se repita por estado


            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
