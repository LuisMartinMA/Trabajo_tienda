using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaVirtual_ETS.Models
{
    public class ProductoOrden: Producto
    {


        [Required(ErrorMessage = "Se necesita ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]  // cambia el formato de los datos en la vista y/o en la BD
        [DataType(DataType.Currency)]

        public float Cantidad { get; set; }                                               

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]  // cambia el formato de los datos en la vista y/o en la BD




        public Decimal Valor { get { return Precio * (decimal)Cantidad;  } }



    }
}





