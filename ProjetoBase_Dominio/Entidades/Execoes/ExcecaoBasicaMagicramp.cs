using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Dominio.Entidades.Execoes
{
    public class ExcecaoBasicaMagicramp : Exception
    {
        public string Mensagem { get; private set; }
        public Exception ExcecaoInterna { get; private set; }
        public ExcecaoBasicaMagicramp(string mensagem) : base(mensagem)
        {
            this.Mensagem = mensagem;
        }
        public ExcecaoBasicaMagicramp(string mensagem, Exception ex) : base(mensagem, ex)
        {
            this.Mensagem = ex.GetType() == typeof(ExcecaoBasicaMagicramp) ? ((ExcecaoBasicaMagicramp)ex).Mensagem : mensagem;
            this.ExcecaoInterna = ex;
        }

        public override string ToString()
        {
            return this.Mensagem;
        }
    }
}
