using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaVirtual_ETS.Models
{
    public class ProveedorProducto
    {

         [Key]
        public int ProveedorProductoID { get; set; }
        public int ProveedorID { get; set; }
        public int ProductoID { get; set; }




        // propiedades virtuales 

        public virtual Proveedor Proveedor { get; set; }

        public virtual Producto Producto { get; set; }


    }
}



















