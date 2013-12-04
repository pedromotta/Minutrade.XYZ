using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositorio
{
    public class Repository<T> : IRepository<T> where T : DbContext
    {
        private T _context = null;

        public Repository(T context)
        {
            _context = context;
        }

        IQueryable<TEntidade> IRepository<T>.Select<TEntidade>()
        {
            return _context.Set<TEntidade>();
        }

        void IRepository<T>.Adicionar<TEntidade>(TEntidade entidade)
        {
            _context.Set<TEntidade>().Add(entidade);
        }

        void IRepository<T>.Editar<TEntidade>(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
        }

        void IRepository<T>.Excluir<TEntidade>(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        int IRepository<T>.Commit()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

        void IDisposable.Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
