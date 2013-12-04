using Library.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parceiro.Negocio.Services
{
    public class Cliente
    {
        public MessageCollection<Dominio.Models.Cliente> ObterClientesIncompleto()
        {
            MessageCollection<Dominio.Models.Cliente> msg = new MessageCollection<Dominio.Models.Cliente>();

            try
            {
                var clientes = Integracao.XYZ.XYZClientes.ClientesIncompletos();

                if (clientes.Resultado != TipoResultado.Sucesso)
                    throw clientes.Exception;

                msg.Instances = clientes.Instances.Select(s => new Dominio.Models.Cliente()
                {
                    Id = s.Idk__BackingField,
                    Nome = s.Nomek__BackingField,
                    Endereco = s.Enderecok__BackingField,
                    TelefoneResidencial = s.TelefoneResidencialk__BackingField,
                    TelefoneCelular = s.TelefoneCelulark__BackingField,
                    DataNascimento = s.DataNascimentok__BackingField
                }).ToList();
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }

        public MessageInstance<Dominio.Models.Cliente> ObterClientePorId(int id)
        {
            MessageInstance<Dominio.Models.Cliente> msg = new MessageInstance<Dominio.Models.Cliente>();

            try
            {
                var cliente = Integracao.XYZ.XYZClientes.ObterCliente(id);

                if (cliente.Resultado != TipoResultado.Sucesso)
                    throw cliente.Exception;

                msg.Instance = new Dominio.Models.Cliente()
                {
                    Id = cliente.Instance.Idk__BackingField,
                    Nome = cliente.Instance.Nomek__BackingField,
                    Endereco = cliente.Instance.Enderecok__BackingField,
                    TelefoneResidencial = cliente.Instance.TelefoneResidencialk__BackingField,
                    TelefoneCelular = cliente.Instance.TelefoneCelulark__BackingField,
                    DataNascimento = cliente.Instance.DataNascimentok__BackingField
                };
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }

        public Message AtualizarCliente(Dominio.Models.Cliente cliente)
        {
            Message msg = new Message();

            try
            {
                Integracao.XYZServiceReference.TbCliente tbCliente = new Integracao.XYZServiceReference.TbCliente()
                {
                    Idk__BackingField = cliente.Id,
                    Nomek__BackingField = cliente.Nome,
                    Enderecok__BackingField = cliente.Endereco,
                    TelefoneResidencialk__BackingField = cliente.TelefoneResidencial,
                    TelefoneCelulark__BackingField = cliente.TelefoneCelular,
                    DataNascimentok__BackingField = cliente.DataNascimento
                };
                
                Integracao.XYZ.XYZClientes.AtualizarCliente(tbCliente);
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }
    }
}
