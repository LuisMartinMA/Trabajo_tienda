﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TiendaVirtual_ETS.Data;
using TiendaVirtual_ETS.Models;

namespace TiendaVirtual_ETS.Controllers
{
    public class EmpleadosController : Controller
    {
        private TiendaVirtual_ETSContext db = new TiendaVirtual_ETSContext();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleadoes = db.Empleadoes.Include(e => e.TipoDocumento);
            return View(empleadoes.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descripcion");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleadoID,Nombre,Apellido,Salario,PorcentajeBono,FechaNacimiento,HoraInicio,Email,URL,TipoDocumentoID")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descripcion", empleado.TipoDocumentoID);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descripcion", empleado.TipoDocumentoID);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleadoID,Nombre,Apellido,Salario,PorcentajeBono,FechaNacimiento,HoraInicio,Email,URL,TipoDocumentoID")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descripcion", empleado.TipoDocumentoID);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {




            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }




        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            db.Empleadoes.Remove(empleado);
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
