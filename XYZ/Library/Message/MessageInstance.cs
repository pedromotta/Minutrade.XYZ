using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Message
{
    /// <summary>
    /// Classe para trafegar um único objeto.
    /// </summary>
    /// <typeparam name="T">Tipo deo objeto a ser trafegado.</typeparam>
    public class MessageInstance<T> : Message where T : class
    {
        public MessageInstance() { }

        public T Instance { get; set; }
    }
}
