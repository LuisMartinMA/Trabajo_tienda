using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtual_ETS.Models
{
    public class Proveedor
    {
        [Key]
       public int ProveedorID { get; set; }

        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [Display(Name = "Nombre")]


        public String Nombre { get; set; }

        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [Display(Name = " Nombre Contacto")]


        public String NombreContacto { get; set; }


        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [Display(Name = " Apellido Contacto")]

        public String ApellidoContacto { get; set; }


        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [Display(Name = " Telefono")]
        public String Telefono { get; set; }


        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [Display(Name = " Direccion")]

        public String  Direccion { get; set; }
        public String  Email { get; set; }


        public virtual ICollection<ProveedorProducto> ProveedorProducto { get; set; }

                                                                                                   

    }
}