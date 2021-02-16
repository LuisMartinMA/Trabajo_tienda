using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TiendaVirtual_ETS.Data
{
    public class TiendaVirtual_ETSContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TiendaVirtual_ETSContext() : base("name=TiendaVirtual_ETSContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<TiendaVirtual_ETS.Models.Producto> Productoes { get; set; }

        public System.Data.Entity.DbSet<TiendaVirtual_ETS.Models.TipoDocumento> TipoDocumentoes { get; set; }

        public System.Data.Entity.DbSet<TiendaVirtual_ETS.Models.Empleado> Empleadoes { get; set; }

        public System.Data.Entity.DbSet<TiendaVirtual_ETS.Models.Proveedor> Proveedors { get; set; }

        public System.Data.Entity.DbSet<TiendaVirtual_ETS.Models.ProveedorProducto> ProveedorProductoes { get; set; }

        public System.Data.Entity.DbSet<TiendaVirtual_ETS.Models.Cliente> Clientes { get; set; }


        public System.Data.Entity.DbSet<TiendaVirtual_ETS.Models.Orden> ordens { get; set; }

        public System.Data.Entity.DbSet<TiendaVirtual_ETS.Models.DetalleOrden> detalleOrdens { get; set; }


    }
}
