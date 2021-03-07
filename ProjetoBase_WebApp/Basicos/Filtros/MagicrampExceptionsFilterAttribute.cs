using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBase_Dominio.Entidades.Execoes;
using ProjetoBase_Dominio.Entidades.Logs;

namespace ProjetoBase_WebApp.Basicos.Filtros
{
    public class MagicrampExceptionsFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                if (filterContext.Exception is ExcecaoBasicaMagicramp)
                {
                    if (EhRequisicaoAjax(filterContext))
                    {
                        filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

                        filterContext.Result = new JsonResult
                        {
                            Data = new { mensagemDeExcecao = filterContext.Exception.Message },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };

                        filterContext.ExceptionHandled = true;
                    }
                }
                else
                {
                    Log.WriteToFile(filterContext.Exception.Message);
                }
            }

            base.OnActionExecuted(filterContext);
        }

        private bool EhRequisicaoAjax(ControllerContext controllerContext)
        {
            var request = controllerContext.RequestContext.HttpContext.Request;
            return request.IsAjaxRequest();
        }
    }
}