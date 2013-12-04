using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace XYZ.WcfIntegracao.Utils
{
    /// <summary>
    /// Classe responsável por prover informações do Web.Config.
    /// </summary>
    public static class Configuracao
    {
        private const string keyClientes = "cliente";

        public static int[] ObterCodigosClientes()
        {
            var values = WebConfigurationManager.AppSettings["cliente"].Split(',');
            
            List<int> codigos = new List<int>();
            
            foreach (var item in values)
            {
                int cod;
                if (int.TryParse(item, out cod))
                {
                    codigos.Add(cod);
                }
            }

            return codigos.ToArray();
        }

        public static bool VerificarCodCliente(int codigo)
        {
            var values = Configuracao.ObterCodigosClientes();

            return values.Where(w => w.Equals(codigo.ToString())).Any();
        }

        public static int QuantidadeClientes()
        {
            return Configuracao.ObterCodigosClientes().Count();
        }
    }
}