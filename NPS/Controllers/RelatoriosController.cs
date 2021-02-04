using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Rotativa;
using Rotativa.Options;
using NPS.Models;

namespace NPS.Controllers
{
    public class RelatoriosController : Controller
    {
        private dbModel db = new dbModel();
        public ActionResult ListagemVotos(int? pagina, Boolean? gerarPDF)
        {

            var listagemVotos = db.Votos.OrderBy(n => n.VotoId)
            .ToList<Voto>();

            if (gerarPDF != true)
            {
                //Definindo a paginação
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemVotos.ToPagedList(paginaNumeroNavegacao,
                paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemVotos",
                    PageSize = Size.A4,
                    IsGrayScale = true,
                    Model = listagemVotos.ToPagedList(paginaNumero, listagemVotos.Count)
                };
                return pdf;
            }
        }

        public ActionResult ListagemSetores(int? pagina, Boolean? gerarPDF)
        {
            var listagemSetores = db.Setores.OrderBy(n => n.SetorId)
            .ToList<Setor>();

            if (gerarPDF != true)
            {
                //Definindo a paginação
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemSetores.ToPagedList(paginaNumeroNavegacao,
                paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemSetores",
                    PageSize = Size.A4,
                    IsGrayScale = true,
                    Model = listagemSetores.ToPagedList(paginaNumero, listagemSetores.Count)
                };
                return pdf;
            }
        }

    }
}