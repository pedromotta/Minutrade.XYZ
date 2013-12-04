using Integracao.XYZServiceReference;
using Library.Message;
using Parceiro.Helpers;
using Parceiro.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parceiro.Controllers
{
    public class IntegracaoController : Controller
    {
        private Negocio.Services.Cliente repositorioClienteService = new Negocio.Services.Cliente();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            var cliService = repositorioClienteService.ObterClientePorId(id);

            if (cliService.Resultado != Library.Message.TipoResultado.Sucesso)
                return View("Error");

            return View(cliService.Instance);
        }

        [HttpPost]
        public ActionResult Editar(Dominio.Models.Cliente cliente)
        {
            Message msg;
            
            msg = repositorioClienteService.AtualizarCliente(cliente);

            if (msg.Resultado != TipoResultado.Sucesso)
                return View("Error", msg.Exception);

            var url = string.Format("{0}?msg={1}",Url.Action("Index"),HttpUtility.UrlEncode(Mensagens.RegistroSalvo));
            Response.Redirect(url, true);
            return View();
        }

        public JsonResult ObterClientes()
        {
            GridCollection result = new GridCollection();
            var clientes = repositorioClienteService.ObterClientesIncompleto();

            var lista = clientes.Instances;

            result.aaData = lista;

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
