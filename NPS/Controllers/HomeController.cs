//Author: Larson Kremer Vicente

using NPS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NPS.Controllers
{
    public class HomeController : Controller
    {
        private dbModel db = new dbModel();
        public ActionResult Index()
        {

            ViewData["Voto"] = GetVotos();
            ViewData["Setor"] = GetSetores();
            return View();
        }

        private List<Voto> GetVotos()
        {
            List<Voto> votos = db.Votos.ToList();
            return votos;
        }

        public List<Setor> GetSetores()
        {
            List<Setor> setores = db.Setores.ToList();
            return setores;
        }
    }
}