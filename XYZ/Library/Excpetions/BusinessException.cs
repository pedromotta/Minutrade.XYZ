using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Excpetions
{
    /// <summary>
    /// Classe de Exceção utilizada para indicar um erro de negócio.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException() : base() { }

        public BusinessException(string msg) : base(msg) { }
    }
}
