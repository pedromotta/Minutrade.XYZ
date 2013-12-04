using Integracao.XYZServiceReference;
using Library.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Integracao.XYZ
{
    /// <summary>
    /// Classe que contém todos os métodos disponíveis no serviço. Ela é responsável por realizar a conexão e realizar a comunicação.
    /// Facilita o uso dos métodos na aplicação.
    /// </summary>
    public static class XYZClientes
    {
        public static MessageCollection<TbCliente> ClientesIncompletos()
        {
            MessageCollection<TbCliente> msg = new MessageCollection<TbCliente>();
            try 
	        {	        
                using (var proxy = new XYZServiceReference.IntegracaoServiceClient())
                {
                    var clientes = proxy.ObterClientesIncompletos();
                    msg.Instances = clientes;
                }
	        }
	        catch (Exception ex)
	        {
                msg.Exception = ex;
	        }

            return msg;
        }

        public static MessageInstance<TbCliente> ObterCliente(int id)
        {
            MessageInstance<TbCliente> msg = new MessageInstance<TbCliente>();
            try
            {
                using (var proxy = new XYZServiceReference.IntegracaoServiceClient())
                {
                    var cliente = proxy.ObterClientePorId(id);
                    msg.Instance = cliente;
                }
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }

        public static Message AtualizarCliente(TbCliente cliente)
        {
            Message msg = new Message();
            try
            {
                using (var proxy = new XYZServiceReference.IntegracaoServiceClient())
                {
                    proxy.AtualizarCliente(cliente);
                }
            }
            catch (FaultException<XYZServiceReference.BusinessFault> fe)
            {
                throw new Exception(fe.Detail.Mensagem);
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }
    }
}
