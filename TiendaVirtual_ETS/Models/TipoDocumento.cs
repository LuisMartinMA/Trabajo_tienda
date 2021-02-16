using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaVirtual_ETS.Models
{
    public class TipoDocumento
    {

        [Key]

        [Display(Name = "Tipo Documento")]  // aparece cuando se crea un empleado

        public int TipoDocumentoID { get; set; }

        [Display(Name = "Documento")] // aparece en el indice de empleado

        public string Descripcion { get; set; }



         // propiedad virtual para mostrar coleccion de datos de la tabla relacionada 

        public virtual ICollection<Empleado> Empleados { get; set;  }
        public virtual ICollection<Cliente> Clientes { get; set; }






    }
}





