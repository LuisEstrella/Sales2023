using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Estado/Departamento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Name { get; set; } = null!;

        //Un estado pertenece a un país
        public Country? Country { get; set; }

        //Muchos estados pertenecen a una ciudad
        public ICollection<City>? Cities { get; set; }

        public int CityNumber => Cities == null ? 0 : Cities.Count;
    }
}
