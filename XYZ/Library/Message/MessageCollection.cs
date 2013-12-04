using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Message
{
    /// <summary>
    /// Classe para trafegar uma lista de dados.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageCollection<T> : Message where T : class
    {
        IList<T> _lista = new List<T>();

        public IList<T> Instances
        {
            get
            {
                return _lista;
            }
            set
            {
                _lista = value;
            }
        }

        private int? _count;
        public int Count
        {
            get
            {
                return _count ?? _lista.Count;
            }
            set
            {
                _count = value;
            }
        }
    }
}
