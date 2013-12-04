using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parceiro.Dominio.Models
{
    /// <summary>
    /// Model identico à entidade retornada pelo Serviço. 
    /// É criada para facilitar o uso em toda a aplicação e reutilizar como Model nas Views.
    /// </summary>
    [Serializable]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TelefoneResidencial { get; set; }
        public string Endereco { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public string TelefoneCelular { get; set; }
    }
}