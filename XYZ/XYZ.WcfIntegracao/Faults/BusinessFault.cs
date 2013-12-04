using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace XYZ.WcfIntegracao.Faults
{
    /// <summary>
    /// Classe responsável por receber dados de uma exception especifica e enviar para o cliente.
    /// </summary>
    [DataContract]
    public class BusinessFault
    {
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Mensagem { get; set; }
        [DataMember]
        public string MensagemInterna { get; set; }
        [DataMember]
        public string StackTrace { get; set; }
    }
}