using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaVirtual_ETS.Models
{
    public class Orden
    {

        [Key]
        public int OrdenID { get; set; }
        public DateTime FechaOrden { get; set; }

        public EstadoOrden EstadoOrden { get; set; } // clase enumerada

        public int ClienteID { get; set; } // clave foranea de tabla cliente



        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<DetalleOrden> DetalleOrdenes { get; set; }

    }
}











