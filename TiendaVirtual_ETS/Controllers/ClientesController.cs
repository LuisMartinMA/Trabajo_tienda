using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TiendaVirtual_ETS.Data;
using TiendaVirtual_ETS.Models;

namespace TiendaVirtual_ETS.Controllers
{
    public class ClientesController : Controller
    {
        private TiendaVirtual_ETSContext db = new TiendaVirtual_ETSContext();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.TipoDocumento);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {

            var lista = db.TipoDocumentoes.ToList();
            lista.Add(new TipoDocumento { TipoDocumentoID = 0, Descripcion = "[Seleccione un tipo de Documento]" });
            lista = lista.OrderBy(c => c.Descripcion).ToList();                                                



            ViewBag.TipoDocumentoID = new SelectList(lista,"TipoDocumentoID", "Descripcion");                                                              
            return View();                                                                                                                                                                      
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,Nombre,Apellidos,Telefono,Direccion,Email,Documento,TipoDocumentoID")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descripcion", cliente.TipoDocumentoID);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descripcion", cliente.TipoDocumentoID);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,Nombre,Apellidos,Telefono,Direccion,Email,Documento,TipoDocumentoID")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descripcion", cliente.TipoDocumentoID);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
