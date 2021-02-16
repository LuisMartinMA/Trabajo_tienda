using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TiendaVirtual_ETS.Models;
using TiendaVirtual_ETS.ViewModels;

namespace TiendaVirtual_ETS.Controllers
{
    [Authorize(Users ="Mesones_Almonacid@etsunp.edu.pe")]
    public class UsuariosController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarioAdministrador = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var usuarios = usuarioAdministrador.Users.ToList();

            var usuariosVista = new List<UsuarioViewModels>();

            foreach (var usuario in usuarios)
            {
                var usuariovista = new UsuarioViewModels
                {
                    UsuarioID = usuario.Id,
                    Nombre = usuario.UserName,
                    Emial = usuario.Email
                };

                usuariosVista.Add(usuariovista);
            }

            return View(usuariosVista);
        }






        public ActionResult Roles(string usuarioID)
        {

            if(string.IsNullOrEmpty(usuarioID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rolAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usuarioAdministrador = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));


            var roles = rolAdministrador.Roles.ToList();
            var usurios = usuarioAdministrador.Users.ToList();

            var usuario = usurios.Find(u => u.Id == usuarioID);

            if (usuario == null)
            {

                return HttpNotFound();

            }

            var rolesVista = new List<RolViewModels>();


            foreach ( var item in usuario.Roles)
            {
                var rol = roles.Find(r => r.Id == item.RoleId);
                var rolVista = new RolViewModels
                {
                    RolID = rol.Id,
                    Nombre = rol.Name
                };

                rolesVista.Add(rolVista);
            }



            var usuarioVista = new UsuarioViewModels
            {
                UsuarioID = usuario.Id,
                Nombre = usuario.UserName,
                Emial = usuario.Email,
                Roles = rolesVista
            };

            return View(usuarioVista);
        }


        public ActionResult AgregarRoles(string usuarioID)
        {



            if (string.IsNullOrEmpty(usuarioID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        
            var usuarioAdministrador = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));        
            var usuarios = usuarioAdministrador.Users.ToList();
            var usuario = usuarios.Find(u => u.Id == usuarioID);


            if (usuario == null)
            {

                return HttpNotFound();

            }



            var usuarioVista = new UsuarioViewModels
            {
                UsuarioID = usuario.Id,
                Nombre = usuario.UserName,
                Emial = usuario.Email
                
            };

            var rolAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var lista = rolAdministrador.Roles.ToList();

            lista.Add(new IdentityRole { Id = "", Name = "[Seleccionar un Rol...]" });
            lista = lista.OrderBy(r => r.Name).ToList();
            ViewBag.RolID = new SelectList(lista, "Id", "Name");


            return View(usuarioVista);



        }

        [HttpPost]
        public ActionResult AgregarRoles(string usuarioID, FormCollection form)
        {
            var rolID = Request["RolID"];

            //
            var rolAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var usuarioAdministrador = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var usuarios = usuarioAdministrador.Users.ToList();
            var usuario = usuarios.Find(u => u.Id == usuarioID);



            var usuarioVista = new UsuarioViewModels
            {
                UsuarioID = usuario.Id,
                Nombre = usuario.UserName,
                Emial = usuario.Email

            };

            if (string.IsNullOrEmpty(rolID))
            {
                ViewBag.Error = "Se Debe Seleccionar un Rol";


                //
               
                
                var lista = rolAdministrador.Roles.ToList();

                lista.Add(new IdentityRole { Id = "", Name = "[Seleccionar un Rol...]" });
                lista = lista.OrderBy(r => r.Name).ToList();
                ViewBag.RolID = new SelectList(lista, "Id", "Name");


                return View(usuarioVista);

            }

            var roles = rolAdministrador.Roles.ToList();
            var rol = roles.Find(r => r.Id == rolID);


            if(!usuarioAdministrador.IsInRole(usuarioID, rol.Name))
            {
                usuarioAdministrador.AddToRole(usuarioID, rol.Name);

            }
        
            //ROLES VISTAS

            var rolesVista = new List<RolViewModels>();


            foreach (var item in usuario.Roles)
            {
                 rol = roles.Find(r => r.Id == item.RoleId);
                var rolVista = new RolViewModels
                {
                    RolID = rol.Id,
                    Nombre = rol.Name
                };

                rolesVista.Add(rolVista);
            }



             usuarioVista = new UsuarioViewModels
            {
                UsuarioID = usuario.Id,
                Nombre = usuario.UserName,
                Emial = usuario.Email,
                Roles = rolesVista
            };

            return View("Roles", usuarioVista);
        }

        
        public ActionResult Eliminar(string usuarioID, string rolID)
        {

            if (string.IsNullOrEmpty(usuarioID) || string.IsNullOrEmpty(rolID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            }
            var rolAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usuarioAdministrador = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var usuario = usuarioAdministrador.Users.ToList().Find(u => u.Id == usuarioID);
            var rol = rolAdministrador.Roles.ToList().Find(r => r.Id == rolID);


            if (usuarioAdministrador.IsInRole(usuario.Id, rol.Name))
            {
                usuarioAdministrador.RemoveFromRoles(usuario.Id, rol.Name);
            }

            var usuarios = usuarioAdministrador.Users.ToList();
            var roles = rolAdministrador.Roles.ToList();
            var rolesVista = new List<RolViewModels>();


            foreach (var item in usuario.Roles)
            {
                rol = roles.Find(r => r.Id == item.RoleId);

                var rolVista = new RolViewModels
                {
                    Nombre = rol.Name,
                    RolID = rol.Id

                };

                rolesVista.Add(rolVista);
            }

            var usuarioVista = new UsuarioViewModels
            {
                Emial = usuario.Email,
                Nombre = usuario.UserName,
                Roles = rolesVista, 
                UsuarioID = usuario.Id
            };


            return View("Roles", usuarioVista);


        }


        //

         public ActionResult EliminarRoles(string usuarioID, string rolID)
        {

            if (string.IsNullOrEmpty(usuarioID) || string.IsNullOrEmpty(rolID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            }
            var rolAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usuarioAdministrador = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var usuario = usuarioAdministrador.Users.ToList().Find(u => u.Id == usuarioID);
            var rol = rolAdministrador.Roles.ToList().Find(r => r.Id == rolID);


            if (usuarioAdministrador.IsInRole(usuario.Id, rol.Name))
            {
                usuarioAdministrador.RemoveFromRoles(usuario.Id, rol.Name);
            }

            var usuarios = usuarioAdministrador.Users.ToList();
            var roles = rolAdministrador.Roles.ToList();
            var rolesVista = new List<RolViewModels>();


            foreach (var item in usuario.Roles)
            {
                rol = roles.Find(r => r.Id == item.RoleId);

                var rolVista = new RolViewModels
                {
                    Nombre = rol.Name,
                    RolID = rol.Id

                };

                rolesVista.Add(rolVista);
            }

            var usuarioVista = "";
           

            return View("Roles", usuarioVista);


        }


        //



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}