using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TiendaVirtual_ETS.Models;

namespace TiendaVirtual_ETS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Data.TiendaVirtual_ETSContext, Migrations.Configuration>());
            ApplicationDbContext db = new ApplicationDbContext();

            CrearRoles(db);
            CrearSuperUsuario(db);
            AgregarPermisosSuperUsuario(db);
            db.Dispose();


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);                                                                              
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }



        private void AgregarPermisosSuperUsuario(ApplicationDbContext db)
        {

            var rolAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usuarioAdministrador = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
     
            var usuario = usuarioAdministrador.FindByName("Mesones_Almonacid@etsunp.edu.pe");


           


            if (!usuarioAdministrador.IsInRole(usuario.Id, "Ver"))
            {
                usuarioAdministrador.AddToRole(usuario.Id, "Ver");
            }



            if (!usuarioAdministrador.IsInRole(usuario.Id, "Crear"))
            {
                usuarioAdministrador.AddToRole(usuario.Id, "Crear");
            }



            if (!usuarioAdministrador.IsInRole(usuario.Id, "Editar"))
            {
                usuarioAdministrador.AddToRole(usuario.Id, "Editar");
            }


            if (!usuarioAdministrador.IsInRole(usuario.Id, "Eliminar"))
            {
                usuarioAdministrador.AddToRole(usuario.Id, "Eliminar");
            }

        }




        private void CrearSuperUsuario(ApplicationDbContext db)
        {
            var usuarioAdministrador = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var usuario = usuarioAdministrador.FindByName("Mesones_Almonacid@etsunp.edu.pe");

            if (usuario == null)
            {
                usuario = new ApplicationUser
                {
                    UserName = "Mesones_Almonacid@etsunp.edu.pe",
                    Email = "Mesones_Almonacid@etsunp.edu.pe"
                };
                usuarioAdministrador.Create(usuario,"MesonesAlmonacid9727.");
            }
        
        }

        private void CrearRoles(ApplicationDbContext db)
        {
            var rolAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!rolAdministrador.RoleExists("Ver"))   
            {
                rolAdministrador.Create(new IdentityRole("Ver"));           
            }



            if (!rolAdministrador.RoleExists("Crear"))
            {
                rolAdministrador.Create(new IdentityRole("Crear"));
            }




            if (!rolAdministrador.RoleExists("Editar"))
            {
                rolAdministrador.Create(new IdentityRole("Editar"));
            }



            if (!rolAdministrador.RoleExists("Eliminar"))
            {
                rolAdministrador.Create(new IdentityRole("Eliminar"));
            }



        }
    }
}
