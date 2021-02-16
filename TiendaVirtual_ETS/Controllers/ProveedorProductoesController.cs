using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual_ETS.Data;
using TiendaVirtual_ETS.Models;

namespace TiendaVirtual_ETS.Controllers
{
    public class ProveedorProductoesController : Controller
    {
        private TiendaVirtual_ETSContext db = new TiendaVirtual_ETSContext();

        // GET: ProveedorProductoes
        public ActionResult Index()
        {
            var proveedorProductoes = db.ProveedorProductoes.Include(p => p.Producto).Include(p => p.Proveedor);
            return View(proveedorProductoes.ToList());
        }

        // GET: ProveedorProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorProducto proveedorProducto = db.ProveedorProductoes.Find(id);
            if (proveedorProducto == null)
            {
                return HttpNotFound();
            }
            return View(proveedorProducto);
        }

        // GET: ProveedorProductoes/Create
        public ActionResult Create()
        {
            ViewBag.ProductoID = new SelectList(db.Productoes, "ProductoID", "Descripcion");
            ViewBag.ProveedorID = new SelectList(db.Proveedors, "ProveedorID", "Nombre");
            return View();
        }

        // POST: ProveedorProductoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProveedorProductoID,ProveedorID,ProductoID")] ProveedorProducto proveedorProducto)
        {
            if (ModelState.IsValid)
            {
                db.ProveedorProductoes.Add(proveedorProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.Productoes, "ProductoID", "Descripcion", proveedorProducto.ProductoID);
            ViewBag.ProveedorID = new SelectList(db.Proveedors, "ProveedorID", "Nombre", proveedorProducto.ProveedorID);
            return View(proveedorProducto);
        }

        // GET: ProveedorProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorProducto proveedorProducto = db.ProveedorProductoes.Find(id);
            if (proveedorProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoID = new SelectList(db.Productoes, "ProductoID", "Descripcion", proveedorProducto.ProductoID);
            ViewBag.ProveedorID = new SelectList(db.Proveedors, "ProveedorID", "Nombre", proveedorProducto.ProveedorID);
            return View(proveedorProducto);
        }

        // POST: ProveedorProductoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProveedorProductoID,ProveedorID,ProductoID")] ProveedorProducto proveedorProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedorProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoID = new SelectList(db.Productoes, "ProductoID", "Descripcion", proveedorProducto.ProductoID);
            ViewBag.ProveedorID = new SelectList(db.Proveedors, "ProveedorID", "Nombre", proveedorProducto.ProveedorID);
            return View(proveedorProducto);
        }

        // GET: ProveedorProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorProducto proveedorProducto = db.ProveedorProductoes.Find(id);
            if (proveedorProducto == null)
            {
                return HttpNotFound();
            }
            return View(proveedorProducto);
        }

        // POST: ProveedorProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProveedorProducto proveedorProducto = db.ProveedorProductoes.Find(id);
            db.ProveedorProductoes.Remove(proveedorProducto);
            db.SaveChanges();
            return RedirectToAction("Index");
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
