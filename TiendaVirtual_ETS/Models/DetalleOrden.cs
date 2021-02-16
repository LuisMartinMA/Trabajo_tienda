using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaVirtual_ETS.Models
{
    public class DetalleOrden
    {
        [Key]
        public int DetalleOrdenID { get; set; }
        public int OrdenID { get; set; }
        public int ProductoID { get; set; }


        [Display(Name = " Descripcion")]                    // se personaliza el nombre de la etiqueta del campo
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Se necesita ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]  // cambia el formato de los datos en la vista y/o en la BD
        [DataType(DataType.Currency)]


        public decimal Precio { get; set; }


        [Required(ErrorMessage = "Se necesita ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]  // cambia el formato de los datos en la vista y/o en la BD
        [DataType(DataType.Currency)]

        public float Cantidad { get; set; }




        public virtual Orden Orden { get; set; }
        public virtual Producto Producto { get; set; }

    }
}