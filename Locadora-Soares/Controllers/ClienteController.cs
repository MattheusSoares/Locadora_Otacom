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
            ViewBag.ID = cliente.ID;
            ViewBag.Nome = cliente.Nome;
            ViewBag.FilmesDisponiveis = filmeDAO.Read_Available();
            return View();
        }
        public ActionResult ErroLogin()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Create(string nome, string login, string senha)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = nome;
            cliente.Login = login;
            cliente.Senha = senha;
            clienteDAO.Create(cliente);
            return RedirectToAction("CadastroSucesso", "Cliente");
        }

        public ActionResult CadastroSucesso()
        {
            return View();
        }

        public ActionResult EditarPerfil(int ID)
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
            return RedirectToAction("EditarPerfilSucesso", "Cliente", clienteDAO.Read_By_ID(ID));
        }

        public ActionResult EditarPerfilSucesso(Cliente cliente)
        {
            ViewBag.ID_Cliente = cliente.ID;
            return View();

        }

        public ActionResult AlugarFilme(int ID_Filme, int ID_Cliente)
        {
            ViewBag.ID_Cliente = ID_Cliente;

            DateTime Horario = DateTime.Now;

            Aluga aluga = new Aluga();
            aluga.ID_Cliente = ID_Cliente;
            aluga.ID_Filme = ID_Filme;
            aluga.Horario = Horario;
            alugaDAO.Create(aluga);
            filmeDAO.Update_to_Rented(ID_Filme);
            return View();
        }

        public ActionResult FilmesAlugados(int ID)
        {
            ViewBag.ID_Cliente = ID;
            return View(alugaDAO.Read_Rented_by_Cliente(ID));
        }

        public ActionResult ReturnCliente(int ID)
        {
            return RedirectToAction("Index", "Cliente", clienteDAO.Read_By_ID(ID));
        }


    }
}