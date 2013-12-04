using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositorio
{
    /// <summary>
    /// Classe responsável pelas operações básicas com o Contexto (Banco de Dados)
    /// </summary>
    /// <typeparam name="T">Contexto</typeparam>
    public interface IRepository<T> : IDisposable
    {
        /// <summary>
        /// Obtém os dados de uma determinada entidade.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <returns></returns>
        IQueryable<TEntidade> Select<TEntidade>() where TEntidade : class;
        
        //IQueryable<TEntidade> Select<TEntidade>(Expression<Func<T, bool>> predicate) where TEntidade : class;
        /// <summary>
        /// Adiciona um novo objeto ao contexto.
        /// </summary>
        /// <typeparam name="TEntidade">Tipo da Entidade</typeparam>
        /// <param name="entidade">Entidade</param>
        void Adicionar<TEntidade>(TEntidade entidade) where TEntidade : class;
        
        /// <summary>
        /// Edita uma determinada entidade no contexto.
        /// </summary>
        /// <typeparam name="TEntidade">Tipo da Entidade</typeparam>
        /// <param name="entidade">Entidade</param>
        void Editar<TEntidade>(TEntidade entidade) where TEntidade : class;
        
        /// <summary>
        /// Exclui uma entidade.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entidade"></param>
        void Excluir<TEntidade>(TEntidade entidade) where TEntidade : class;
        
        /// <summary>
        /// Sincroniza o contexto com o banco de dados e atualiza o banco.
        /// </summary>
        /// <returns>Número de registros afetados.</returns>
        int Commit();
    }
}
