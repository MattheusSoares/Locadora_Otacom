using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locadora_Soares.Models;
using Locadora_Soares.Persistence;

namespace Locadora_Soares.Controllers
{

    public class HomeController : Controller
    {
        private ClienteDAO DAO = new ClienteDAO();

        public ActionResult Index()
        {
            ViewBag.user_layout = "inicio";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo a Locadora Soares";
            ViewBag.session_status = "nao_logado";
            return View();
        }

        public ActionResult Login(string login, string senha)
        {
            Cliente cliente = new Cliente
            {
                Login = login,
                Senha = senha
            };
            cliente = DAO.Login(cliente);
            if(cliente == null)
            {
                return RedirectToAction("ErroLogin", "Cliente");
            }
            else
            {
                return RedirectToAction("Index", "Cliente", cliente);

            }
        }

    }
}