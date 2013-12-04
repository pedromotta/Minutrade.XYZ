using Library.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repositorio;
using XYZ.Dominio;

namespace XYZ.Repositorio.Models
{
    /// <summary>
    /// Operações básicas para todas as entidades
    /// </summary>
    /// <typeparam name="T">tipo da entidade</typeparam>
    public class RepositorioBase<T> where T : class
    {
        public Message Adicionar(T entidade)
        {
            var msg = new Message();
            try 
	        {
                using (IRepository<DB_XYZContext> context = new Repository<DB_XYZContext>(Contexto.Atual))
                {
                    context.Adicionar(entidade);
                    context.Commit();
                }
	        }
	        catch (Exception ex)
	        {
                msg.Exception = ex;
	        }

            return msg;
        }

        public Message Excluir(T entidade)
        {
            var msg = new Message();
            try
            {
                using (IRepository<DB_XYZContext> context = new Repository<DB_XYZContext>(Contexto.Atual))
                {
                    context.Excluir(entidade);
                    context.Commit();
                }
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }

        public Message Editar(T entidade)
        {
            var msg = new Message();
            try
            {
                using (IRepository<DB_XYZContext> context = new Repository<DB_XYZContext>(Contexto.Atual))
                {
                    context.Editar(entidade);
                    context.Commit();
                }
            }
            catch (Exception ex)
            {
                msg.Exception = ex;
            }

            return msg;
        }

        public MessageCollection<T> ObterTodos()
        {
            var msg = new MessageCollection<T>();
            try
            {
                using (IRepository<DB_XYZContext> context = new Repository<DB_XYZContext>(Contexto.Atual))
                {
                    msg.Instances = (from t in context.Select<T>()
                                    select t).ToList();
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
