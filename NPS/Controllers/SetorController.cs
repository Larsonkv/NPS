using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NPS.Models;

namespace NPS.Controllers
{
    public class SetorController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Setor
        public ActionResult Index()
        {
            return View(db.Setores.ToList());
        }


        // GET: Setor/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SetorId,Nome")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                db.Setores.Add(setor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setor);
        }

        // GET: Setor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setor setor = db.Setores.Find(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SetorId,Nome")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setor);
        }

        // GET: Setor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setor setor = db.Setores.Find(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: Setor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setor setor = db.Setores.Find(id);
            db.Setores.Remove(setor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Setors/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                Setor setor = db.Setores.Find(id);
                ViewBag.Message = setor.Nome;
                ViewData["Voto"] = GetVotos(id);
                var model = (from p in db.Votos
                             where p.SetorId == id
                             select p).ToList();

                if (model == null)
                    return View("Error");
                else
                    return View(model);
            }
            finally
            {
                if (db != null) db.Dispose();
            }
        }

        private List<Voto> GetVotos(int id)
        {
            List<Voto> votos = db.Votos.Where(v => v.SetorId == id).ToList();
            return votos;
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