using Library.Message;
using Library.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZ.Dominio;

namespace XYZ.Repositorio.Models
{
    /// <summary>
    /// Repositório contendo métodos específicos de Cliente
    /// </summary>
    public class Cliente : RepositorioBase<TbCliente>
    {
        public Cliente()
        {
        }

        public MessageCollection<TbCliente> ObterClientesIncompletos()
        {
            MessageCollection<TbCliente> msg = new MessageCollection<TbCliente>();
            try
            {
                msg = this.ObterTodos();

                if (msg.Resultado != TipoResultado.Sucesso)
                    throw msg.Exception;

                msg.Instances = msg.Instances.Where(w => !w.DataNascimento.HasValue || string.IsNullOrEmpty(w.TelefoneCelular)).ToList();
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }

        public MessageInstance<TbCliente> ObterClientePorId(int id)
        {
            MessageInstance<TbCliente> msg = new MessageInstance<TbCliente>();
            try
            {
                using (IRepository<DB_XYZContext> context = new Repository<DB_XYZContext>(Contexto.Atual))
                {
                    var cliente = (from c in context.Select<TbCliente>()
                                   where c.Id == id
                                   select c).FirstOrDefault();

                    msg.Instance = cliente;
                }

            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }

        /// <summary>
        /// Edita um registro de Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public Message EditarCliente(TbCliente cliente)
        {
            Message msg = new Message();
            try
            {
                using(IRepository<DB_XYZContext> context = new Repository<DB_XYZContext>(Contexto.Atual))
	            {
                    var cli = (from c in context.Select<TbCliente>()
                               where c.Id == cliente.Id
                               select c).FirstOrDefault();
                    
                    cli.DataNascimento = cliente.DataNascimento;
                    cli.TelefoneCelular = cliente.TelefoneCelular;
                    this.Editar(cli);
                    context.Commit();
	            }
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }

        /// <summary>
        /// Edita um registro de Cliente vindo de fora.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public Message EditarClienteService(TbCliente cliente)
        {
            Message msg = new Message();
            try
            {
                using (IRepository<DB_XYZContext> context = new Repository<DB_XYZContext>(Contexto.Atual))
                {
                    var cli = (from c in context.Select<TbCliente>()
                               where c.Id == cliente.Id
                               select c).FirstOrDefault();

                    if (!string.IsNullOrEmpty(cliente.TelefoneCelular) && cliente.DataNascimento.HasValue)
                        throw new Library.Excpetions.BusinessException("Este cliente não pode ser editado.");

                    cli.DataNascimento = cliente.DataNascimento;
                    cli.TelefoneCelular = cliente.TelefoneCelular;

                    this.EditarCliente(cliente);
                }
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }
    }
}
