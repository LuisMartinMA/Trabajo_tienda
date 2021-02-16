using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaVirtual_ETS.Models;

namespace TiendaVirtual_ETS.ViewModels
{
    public class OrdenViewModels
    {

        public Cliente Cliente {get; set;}

        public ProductoOrden Producto { get; set; } // siemplemente para manejar los titulos

        public List<ProductoOrden> Productos { get; set; }
    }
}


















