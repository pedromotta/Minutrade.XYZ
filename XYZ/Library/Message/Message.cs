using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Message
{
    /// <summary>
    /// Classe para realizar operações.
    /// </summary>
    [Serializable]
    public class Message
    {
        public Message() 
        {
            this.Resultado = TipoResultado.Sucesso;
            this.Descricao = "Sucesso";
        }

        private TipoResultado _tipoResultado;
        public TipoResultado Resultado 
        {
            get
            {
                return this._tipoResultado;
            }
            set
            {
                _tipoResultado = value;

                if (value != TipoResultado.Sucesso)
                    this.success = false;
                else
                    this.success = true;
            }
        }

        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public bool success { get; set; }

        public dynamic DadoAux { get; set; }

        /// <summary>
        /// Armazena um certo tipo de Exceção.
        /// </summary>
        private Exception _exception;
        public Exception Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                if(value is Exception)
                {
                    Resultado = TipoResultado.Erro;
                    this.Codigo = this.Codigo == 0 ? -1 : this.Codigo;
                    this.Descricao = value.Message;
                }

                _exception = value;
            }
        }
    }
}
