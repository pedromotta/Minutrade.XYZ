using Library.Excpetions;
using Library.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;
using XYZ.Dominio;
using XYZ.WcfIntegracao.Contratos;
using XYZ.WcfIntegracao.Faults;

namespace XYZ.WcfIntegracao
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IntegracaoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IntegracaoService.svc or IntegracaoService.svc.cs at the Solution Explorer and start debugging.
    public class IntegracaoService : IIntegracaoService
    {
        public List<TbCliente> ObterClientesIncompletos()
        {
            MessageCollection<TbCliente> msg;
            List<TbCliente> clientes = new List<TbCliente>();
            var a = WebConfigurationManager.AppSettings["cliente"];

            var repo = new Repositorio.Models.Cliente();
            
            msg = repo.ObterClientesIncompletos();
            clientes = msg.Instances.ToList();

            return msg.Instances.ToList();
        }

        public TbCliente ObterClientePorId(int id)
        {
            MessageInstance<TbCliente> msg;

            var repo = new Repositorio.Models.Cliente();

            msg = repo.ObterClientePorId(id);

            if (msg.Resultado != TipoResultado.Sucesso)
                throw msg.Exception;

            return msg.Instance;
        }

        public void AtualizarCliente(Dominio.TbCliente cliente)
        {
            try
            {
                Message msg;

                var repo = new Repositorio.Models.Cliente();

                msg = repo.EditarClienteService(cliente);

                if (msg.Resultado != TipoResultado.Sucesso)
                    throw msg.Exception;
            }
            catch (BusinessException be)
            {
                BusinessFault bf = new BusinessFault();
                bf.Titulo = "Erro de negócio";
                bf.Mensagem = be.Message;
                bf.StackTrace = be.StackTrace;

                throw new FaultException<BusinessFault>(bf, bf.Titulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }
    }
}
