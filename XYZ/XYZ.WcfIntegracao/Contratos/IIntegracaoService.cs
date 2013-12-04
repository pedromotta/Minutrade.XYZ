using Library.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using XYZ.Dominio;

namespace XYZ.WcfIntegracao.Contratos
{
    [ServiceContract]
    public interface IIntegracaoService
    {
        /// <summary>
        /// Disponibiliza uma lista dos clientes que precisam ser editados.
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [OperationContract]
        List<TbCliente> ObterClientesIncompletos();

        /// <summary>
        /// Seleciona um cliente pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <returns>Cliente</returns>
        [OperationContract]
        TbCliente ObterClientePorId(int id);

        /// <summary>
        /// Atualiza um cliente.
        /// Só podem ser editados clientes com Celular e Data de Nascimento não preenchidos.
        /// </summary>
        /// <param name="cliente">Cliente</param>
        [OperationContract]
        [FaultContract(typeof(WcfIntegracao.Faults.BusinessFault))]
        void AtualizarCliente(Dominio.TbCliente cliente);
    }
}
