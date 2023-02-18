using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]


    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            if (country == null) { return BadRequest(); }

            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok( await _context.Countries.ToListAsync());
        }
        
    }
}
