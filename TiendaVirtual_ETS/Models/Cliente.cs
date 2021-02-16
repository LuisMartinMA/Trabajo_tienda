using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaVirtual_ETS.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Display(Name = "Nombre Cliente")]                    // se personaliza el nombre de la etiqueta del campo
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]

        public string Nombre { get; set; }


        [Display(Name = "Apellidos Cliente")]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]
        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]                                                                                       
        public string Apellidos { get; set; }


        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [Display(Name = " Telefono")]
        public string Telefono { get; set; }



        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [Display(Name = " Direccion")]

        public string Direccion { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [Display(Name = " Documento")]                                                                                               
        public string Documento { get; set; }


        public string NombreCompleto { get { return string.Format("{0} {1}", Nombre, Apellidos); } }


        public int TipoDocumentoID { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }

        public virtual ICollection<Orden> Ordenes { get; set; }         


    }
}