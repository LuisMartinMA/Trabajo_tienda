using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtual_ETS.Models
{
    public class Producto
    {

			// metodo
	          [Key]
			public int ProductoID { get; set; }


	                                           // se personaliza el nombre de la etiqueta del campo
		[StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
		[Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
		[Display(Name = " Descripcion")]


		public string Descripcion { get; set; }


		[Required(ErrorMessage = "Se necesita ingresar {0}")]
		[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]  // cambia el formato de los datos en la vista y/o en la BD
		[DataType(DataType.Currency)]

		public decimal Precio { get; set; }



		[Display(Name = " Fec. Compra")]
		[Required(ErrorMessage = "Se necesita ingresar {0}")]
		[DisplayFormat(DataFormatString = "{0:yyy/MM/dd}", ApplyFormatInEditMode = true)]  // cambia el formato de los datos en la vista y/o en la BD
		[DataType(DataType.Date)]

		public DateTime FechaCompra { get; set; }

		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]  // cambia el formato de los datos en la vista y/o en la BD

		public float Stock { get; set; }


		[DataType(DataType.MultilineText)]
			public string Observaciones { get; set; }


		 
		public virtual ICollection<ProveedorProducto> ProveedorProducto { get; set; }

		public virtual ICollection<DetalleOrden> DetalleOrdenes { get; set; }         

	}
}










