using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locadora_Soares.Models;
using Locadora_Soares.Persistence;

namespace Locadora_Soares.Persistence
{
    public class AdminController : Controller
    {
        private AdminDAO adminDAO = new AdminDAO();
        private ClienteDAO clienteDAO = new ClienteDAO();
        private FilmeDAO filmeDAO = new FilmeDAO();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string login, string senha)
        {
            Admin admin = new Admin();
            admin.Login = login;
            admin.Senha = senha;
            admin = adminDAO.LoginSU(admin);
            if (admin == null)
            {
                return RedirectToAction("ErroLogin", "Admin");
            }
            else
            {
                return RedirectToAction("AdminMain", "Admin");
            }
        }
        public ActionResult ErroLogin()
        {
            return View();
        }

        public ActionResult AdminMain()
        {
            return View();
        }

        public ActionResult CadastrarCliente()
        {
            return View();
        }
        public ActionResult CreateCliente(string nome, string login, string senha)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = nome;
            cliente.Login = login;
            cliente.Senha = senha;
            clienteDAO.Create(cliente);
            return RedirectToAction("CadastroClienteSucesso", "Admin");
        }
        public ActionResult CadastroClienteSucesso()
        {
            return View();
        }

        public ActionResult ListarCliente()
        {
            return View(clienteDAO.Read_All());
        }

        public ActionResult EditarCliente(int ID)
        {
            return View(clienteDAO.Read_By_ID(ID));
        }

        public ActionResult UpdateCliente(int ID, string nome, string login, string senha)
        {
            Cliente cliente = new Cliente();
            cliente.ID = ID;
            cliente.Nome = nome;
            cliente.Login = login;
            cliente.Senha = senha;
            clienteDAO.Update(cliente);
            return RedirectToAction("EditarClienteSucesso", "Admin");
        }
        public ActionResult EditarClienteSucesso()
        {
            return View();
        }

        public ActionResult ExcluirCliente(int ID)
        {
            clienteDAO.Delete(ID);
            return View();
        }


        public ActionResult CadastrarFilme()
        {
            return View();
        }

        public ActionResult CreateFilme(string nome, int ano, string categoria)
        {
            Filme filme = new Filme();
            filme.Nome = nome;
            filme.Ano = ano;
            filme.Categoria = categoria;

            filmeDAO.Create(filme);
            return RedirectToAction("CadastroFilmeSucesso", "Admin");
        }

        public ActionResult CadastroFilmeSucesso()
        {
            return View();
        }
        public ActionResult ListarFilme()
        {
            return View(filmeDAO.Read_All());
        }

        public ActionResult EditarFilme(int ID)
        {
            return View(filmeDAO.Read_By_ID(ID));
        }

        public ActionResult UpdateFilme(int ID, string nome, int ano, string categoria)
        {
            Filme filme = new Filme();
            filme.ID = ID;
            filme.Nome = nome;
            filme.Ano = ano;
            filme.Categoria = categoria;
            filmeDAO.Update(filme);
            return RedirectToAction("EditarFilmeSucesso", "Admin");
        }
        public ActionResult EditarFilmeSucesso()
        {
            return View();
        }

        public ActionResult ExcluirFilme(int ID)
        {
            filmeDAO.Delete(ID);
            return View();
        }

        //ALTERAR
        public ActionResult ListarFilmesCliente(int ID)
        {
            return View(filmeDAO.Read_Rented(ID));
        }

        //ALTERAR
        public ActionResult DevolucaoFilme(int ID, string nome, int ano, string categoria, int ID_Cliente)
        {
            ViewBag.ID_Cliente = ID_Cliente;
            filmeDAO.Update_Rent(ID);
            return View();
        }


    }
}