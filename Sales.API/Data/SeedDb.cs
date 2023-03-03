using Sales.Shared.Entities;

namespace Sales.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync(); //si no hay bd la crea
            await CheckCountriesAsync();
            await CheckCategoriesAsync();

        }

        private async Task CheckCountriesAsync()
        {
            if(!_context.Countries.Any()) //Any es si hay algun registro devuelva true
            {
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "Perú" });
                _context.Countries.Add(new Country { Name = "México" });
                await _context.SaveChangesAsync();
            }
        } 
        private async Task CheckCategoriesAsync()
        {
            if(!_context.Categories.Any()) //Any es si hay algun registro devuelva true
            {
                _context.Categories.Add(new Category { Name = "Camisetas" });
                _context.Categories.Add(new Category { Name = "Pantalones" });
                _context.Categories.Add(new Category { Name = "Ropa Deportiva" });
                _context.Categories.Add(new Category { Name = "Joggers" });
                _context.Categories.Add(new Category { Name = "Buzos y Chaquetas" });
                _context.Categories.Add(new Category { Name = "Camisas" });
                _context.Categories.Add(new Category { Name = "Polos" });
                _context.Categories.Add(new Category { Name = "Medias" });
                _context.Categories.Add(new Category { Name = "Zapatos" });
                _context.Categories.Add(new Category { Name = "Gorras" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
