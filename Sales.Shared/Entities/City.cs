﻿using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Name { get; set; } = null!;

        //Un ciudad pertenece a un estado
        public int StateId { get; set; }

        //Un ciudad pertenece a un departamento
        public State? State { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
