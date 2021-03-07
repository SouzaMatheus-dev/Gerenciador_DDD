using ProjetoBase_WebApp.Basicos.Atributos;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBase_WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AutorizacaoAttribute());

        }
    }
}
