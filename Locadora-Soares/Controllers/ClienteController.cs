using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locadora_Soares.Models;
using Locadora_Soares.Persistence;

namespace Locadora_Soares.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteDAO clienteDAO = new ClienteDAO();
        private AlugaDAO alugaDAO = new AlugaDAO();
        private FilmeDAO filmeDAO = new FilmeDAO();

        public ActionResult Index(Cliente cliente)
        {
            ViewBag.user_layout = "usuario";
            ViewBag.user = cliente.Nome;
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo " + cliente.Nome;
            ViewBag.session_status = "logado";

            ViewBag.ID_Cliente = cliente.ID;
            ViewBag.FilmesDisponiveis = filmeDAO.Read_Available();
            return View();
        }
        public ActionResult ErroLogin()
        {
            ViewBag.user_layout = "inicio";
            ViewBag.title_welcome = "Erro de credenciais";
            ViewBag.title = "";
            ViewBag.session_status = "nao_logado";
            return View();
        }

        public ActionResult Cadastrar()
        {
            ViewBag.user_layout = "inicio";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo a Locadora Soares";
            ViewBag.session_status = "nao_logado";
            return View();
        }

        public ActionResult Create(string nome, string login, string senha)
        {
            Cliente cliente = new Cliente(nome,login,senha);
            clienteDAO.Create(cliente);
            return RedirectToAction("CadastroSucesso", "Cliente");
        }

        public ActionResult CadastroSucesso()
        {
            ViewBag.user_layout = "inicio";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo a Locadora Soares";
            ViewBag.session_status = "nao_logado";
            return View();
        }

        public ActionResult EditarPerfil(int ID)
        {
            Cliente cliente = clienteDAO.Read_By_ID(ID);

            ViewBag.user_layout = "usuario";
            ViewBag.user = cliente.Nome;
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo " + cliente.Nome;
            ViewBag.session_status = "logado";

            ViewBag.ID_Cliente = cliente.ID;

            return View(cliente);
        }

        public ActionResult UpdateCliente(int ID, string nome, string login, string senha)
        {
            Cliente cliente = new Cliente(ID,nome,login,senha);
            clienteDAO.Update(cliente);
            return RedirectToAction("EditarPerfilSucesso", "Cliente", clienteDAO.Read_By_ID(ID));
        }

        public ActionResult EditarPerfilSucesso(Cliente cliente)
        {
            ViewBag.user_layout = "usuario";
            ViewBag.user = cliente.Nome;
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo " + cliente.Nome;
            ViewBag.session_status = "logado";

            ViewBag.ID_Cliente = cliente.ID;
            return View();

        }

        public ActionResult AlugarFilme(int ID_Filme, int ID_Cliente)
        {
            Cliente cliente = clienteDAO.Read_By_ID(ID_Cliente);

            ViewBag.user_layout = "usuario";
            ViewBag.user = cliente.Nome;
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo " + cliente.Nome;
            ViewBag.session_status = "logado";

            ViewBag.ID_Cliente = cliente.ID;

            DateTime Horario = DateTime.Now;

            Aluga aluga = new Aluga(ID_Cliente,ID_Filme,Horario);
            alugaDAO.Create(aluga);
            filmeDAO.Update_to_Rented(ID_Filme);
            return View();
        }

        public ActionResult FilmesAlugados(int ID)
        {
            Cliente cliente = clienteDAO.Read_By_ID(ID);

            ViewBag.user_layout = "usuario";
            ViewBag.user = cliente.Nome;
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo " + cliente.Nome;
            ViewBag.session_status = "logado";

            ViewBag.ID_Cliente = ID;

            return View(alugaDAO.Read_Rented_by_Cliente(ID));
        }

        public ActionResult ReturnCliente(int ID)
        {
            return RedirectToAction("Index", "Cliente", clienteDAO.Read_By_ID(ID));
        }


    }
}