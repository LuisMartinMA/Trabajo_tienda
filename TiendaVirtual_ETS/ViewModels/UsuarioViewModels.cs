using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaVirtual_ETS.ViewModels
{
    public class UsuarioViewModels
    {

        public string UsuarioID { get; set; }

        public string Nombre { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Emial { get; set; }


        public RolViewModels Rol { get; set; }  // Manipular los titulos


        public List<RolViewModels> Roles { get; set; }
    }

}