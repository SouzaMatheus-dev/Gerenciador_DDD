using ProjetoBase_Dominio.Autenticacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBase_WebApp.Basicos.Atributos
{
    public class AutorizacaoAttribute : AuthorizeAttribute
    {
        private string[] Perfis { get; set; }


        public AutorizacaoAttribute()
        {
        }

        public AutorizacaoAttribute(params string[] perfis)
        {
            this.Perfis = perfis;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var principal = ContextoPrincipal.Principal;

            if (principal != null)
            {
                if (this.Perfis != null)
                {
                    foreach (var perfil in this.Perfis)
                    {
                        if (principal.Grupo == perfil)
                            return true;
                    }

                    return false;
                }

                return true;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (ContextoPrincipal.Principal != null)
            {
                filterContext.Result = new RedirectResult("~/Login/NaoAutorizado");
                return;
            }

            filterContext.Result = new RedirectResult("~/Login/Login");
        }
    }
}