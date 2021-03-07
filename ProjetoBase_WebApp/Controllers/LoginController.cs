using ProjetoBase_Dominio.Autenticacao;
using ProjetoBase_WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBase_WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            if (ContextoPrincipal.Principal != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                //if (this.ServicoDeAutenticacao.AutentiqueUsuario(login.Email, login.Senha))
                    return RedirectToAction("Index", "Home");

                //ModelState.AddModelError("err", "Usuário e/ou senha incorretos");
            }

            return View(login);
        }

        public ActionResult NaoAutorizado()
        {
            return View();
        }
    }
}