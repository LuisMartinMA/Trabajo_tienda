using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TiendaVirtual_ETS.Data;
using TiendaVirtual_ETS.Models;
using TiendaVirtual_ETS.ViewModels;

namespace TiendaVirtual_ETS.Controllers
{
    public class OrdenesController : Controller
    {

        TiendaVirtual_ETSContext db = new TiendaVirtual_ETSContext();


        // GET: Ordenes
        public ActionResult NuevaOrden()
        {
            var ordeViewModels = new OrdenViewModels();
            ordeViewModels.Cliente = new Cliente();
            ordeViewModels.Productos = new List<ProductoOrden>();
            Session["ordenViewModels"] = ordeViewModels;

            var lista = db.Clientes.ToList();
            lista.Add(new Cliente { ClienteID = 0, Nombre = "[Seleccionar un Cliente...]" });
            lista = lista.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClienteID = new SelectList(lista, "ClienteID", "NombreCompleto");


            return View(ordeViewModels);
        }




        // POST: Ordenes
        [HttpPost]
        public ActionResult NuevaOrden(OrdenViewModels ordenViewModels)
        {

            ordenViewModels = Session["ordenViewModels"] as OrdenViewModels;

            var clienteID = int.Parse(Request["ClienteID"]);

            if (clienteID == 0)
            {

                var lista = db.Clientes.ToList();
                lista.Add(new Cliente { ClienteID = 0, Nombre = "[Seleccionar un Cliente...]" });
                lista = lista.OrderBy(c => c.NombreCompleto).ToList();
                ViewBag.ClienteID = new SelectList(lista, "ClienteID", "NombreCompleto");

                ViewBag.Error = "Debes seleccionar un cliente";

                return View(ordenViewModels);

            }




            var cliente = db.Clientes.Find(clienteID);
            if (cliente == null)
            {

                var lista = db.Clientes.ToList();
                lista.Add(new Cliente { ClienteID = 0, Nombre = "[Seleccionar un Cliente...]" });
                lista = lista.OrderBy(c => c.NombreCompleto).ToList();
                ViewBag.ClienteID = new SelectList(lista, "ClienteID", "NombreCompleto");

                ViewBag.Error = "cliente no existe";

                return View(ordenViewModels);

            }

            if (ordenViewModels.Productos.Count == 0)
            {


                var lista = db.Clientes.ToList();
                lista.Add(new Cliente { ClienteID = 0, Nombre = "[Seleccionar un Cliente...]" });
                lista = lista.OrderBy(c => c.NombreCompleto).ToList();
                ViewBag.ClienteID = new SelectList(lista, "ClienteID", "NombreCompleto");

                ViewBag.Error = "No se ingresaron productos a la orden";

                return View(ordenViewModels);


            }







            int ordenID = 0;

            
        //    int i = 0; // borrarrrrrrrrrrrrr




            // TRNSACCION

            using (var transaccion = db.Database.BeginTransaction())
            {

                try 
                {


                    var orden = new Orden
                    {

                        ClienteID = clienteID,
                        FechaOrden = DateTime.Now,
                        EstadoOrden = EstadoOrden.Creada

                    };

                    db.ordens.Add(orden);
                    db.SaveChanges();


                    ordenID = db.ordens.ToList().Select(o => o.OrdenID).Max();

                    foreach (var item in ordenViewModels.Productos)
                    {
                        var detalleOrden = new DetalleOrden
                        {
                            ProductoID = item.ProductoID,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            Cantidad = item.Cantidad,
                            OrdenID = ordenID
                        };

                        db.detalleOrdens.Add(detalleOrden);
                        db.SaveChanges();





                        // borrar


                   /*
                        i++;
                        if (i > 1 )
                        {
                            int a = 0;
                            i = i/a;
                        }

                        */


                    }


                    transaccion.Commit();

                }
                catch (Exception ex)
                {

                    transaccion.Rollback();
                    ViewBag.Error = "Error: " + ex.Message;



                    var listaC = db.Clientes.ToList();
                    listaC.Add(new Cliente { ClienteID = 0, Nombre = "[Seleccionar un Cliente...]" });
                    listaC = listaC.OrderBy(c => c.NombreCompleto).ToList();
                    ViewBag.ClienteID = new SelectList(listaC, "ClienteID", "NombreCompleto");


                    return View(ordenViewModels);

                }




            }










            ViewBag.Message = string.Format("La orden {0} , se guardo correctamente",ordenID);
      
            
            var listaCli = db.Clientes.ToList();
            listaCli.Add(new Cliente { ClienteID = 0, Nombre = "[Seleccionar un Cliente...]" });
            listaCli = listaCli.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClienteID = new SelectList(listaCli, "ClienteID", "NombreCompleto");




            ordenViewModels = new OrdenViewModels();
            ordenViewModels.Cliente = new Cliente();
            ordenViewModels.Productos = new List<ProductoOrden>();
            Session["ordenViewModels"] = ordenViewModels;

            return View(ordenViewModels);
        }





        // GET

        public ActionResult AgregarProducto()
        {

            var lista = db.Productoes.ToList();
            lista.Add(new ProductoOrden { ProductoID = 0, Descripcion = "[Seleccionar un Producto...]" });
            lista = lista.OrderBy(p => p.Descripcion).ToList();
            ViewBag.ProductoID = new SelectList(lista, "ProductoID", "Descripcion");

            return View();

        }


        // POST
        [HttpPost]
        public ActionResult AgregarProducto(ProductoOrden productoOrden)
        {

            var ordenViewModels = Session["ordenViewModels"] as OrdenViewModels;

            var productoID = int.Parse(Request["ProductoID"]); // se jala del producto elegido en el combobox
           
            if (productoID == 0)
            {
                var lista = db.Productoes.ToList();
                lista.Add(new ProductoOrden { ProductoID = 0, Descripcion = "[Seleccionar un Producto...]" });
                lista = lista.OrderBy(p => p.Descripcion).ToList();
                ViewBag.ProductoID = new SelectList(lista, "ProductoID", "Descripcion");


                ViewBag.Error = "Debes seleccionar un producto";

                return View(productoOrden);
            }




            var producto = db.Productoes.Find(productoID);

            if (producto == null)
            {

                var lista = db.Productoes.ToList();
                lista.Add(new ProductoOrden { ProductoID = 0, Descripcion = "[Seleccionar un Producto...]" });
                lista = lista.OrderBy(p => p.Descripcion).ToList();
                ViewBag.ProductoID = new SelectList(lista, "ProductoID", "Descripcion");

                ViewBag.Error = "Producto no existe";

                return View(productoOrden);
            }

            productoOrden = ordenViewModels.Productos.Find(p => p.ProductoID == productoID);
             if (productoOrden == null)
            {

                productoOrden = new ProductoOrden
                {
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    ProductoID = producto.ProductoID,
                    Cantidad = float.Parse(Request["Cantidad"])
                };

                ordenViewModels.Productos.Add(productoOrden);

            }

            else
            {
                productoOrden.Cantidad += float.Parse(Request["Cantidad"]);
            }


        


            var listac = db.Clientes.ToList();
            listac.Add(new Cliente { ClienteID = 0, Nombre = "[Seleccionar un Cliente...]" });
            listac = listac.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClienteID = new SelectList(listac, "ClienteID", "NombreCompleto");


            return View("NuevaOrden", ordenViewModels);

    
       

        }



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































