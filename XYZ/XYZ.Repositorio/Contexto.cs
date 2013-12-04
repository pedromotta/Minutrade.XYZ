using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Dominio
{
    /// <summary>
    /// Classe estática responsável por gerencia o Contexto do banco de dados.
    /// </summary>
    public static class Contexto
    {
        /// <summary>
        /// Retorna o Contexto atual.
        /// </summary>
        private static DB_XYZContext contexto = null;
        public static DB_XYZContext Atual
        {
            get
            {
                contexto = new DB_XYZContext();
                return contexto;
            }
        }
    }
}
