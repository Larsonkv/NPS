using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NPS.Models;

namespace NPS.Controllers
{
    public class VotoController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Voto
        public ActionResult Index()
        {
            var votos = db.Votos.Include(v => v.Setor);
            return View(votos.ToList());
        }

        // GET: Voto/Create
        public ActionResult Create()
        {
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VotoId,Vl_voto,Nr_telefone,Justificativa_voto,SetorId")] Voto voto)
        {
            if (ModelState.IsValid)
            {
                db.Votos.Add(voto);
                db.SaveChanges();
                return RedirectToAction("PosVoto");
            }

            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Nome", voto.SetorId);
            return View(voto);
        }

        // GET: Voto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voto voto = db.Votos.Find(id);
            if (voto == null)
            {
                return HttpNotFound();
            }
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Nome", voto.SetorId);
            return View(voto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VotoId,Vl_voto,Nr_telefone,Justificativa_voto,SetorId")] Voto voto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SetorId = new SelectList(db.Setores, "SetorId", "Nome", voto.SetorId);
            return View(voto);
        }

        // GET: Voto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voto voto = db.Votos.Find(id);
            if (voto == null)
            {
                return HttpNotFound();
            }
            return View(voto);
        }

        // POST: Voto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voto voto = db.Votos.Find(id);
            db.Votos.Remove(voto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PreVoto()
        {
            return View();
        }

        public ActionResult PosVoto()
        {
            return View();
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