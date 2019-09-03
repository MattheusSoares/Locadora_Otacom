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
        private FilmeDAO filmeDAO = new FilmeDAO();
        // GET: Cliente
        public ActionResult Index(Cliente cliente)
        {
            ViewBag.ID = cliente.ID;
            ViewBag.Nome = cliente.Nome;
            return View(filmeDAO.Read_Available());
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
            return RedirectToAction("Index", "Cliente", cliente);
        }

        //ALTERAR
        public ActionResult AlugarFilme(int ID, string nome, int ano, string categoria, int ID_Cliente)
        {
            Filme filme = new Filme();
            filme.ID = ID;
            filme.Nome = nome;
            filme.Ano = ano;
            filme.Categoria = categoria;
            filme.ID_Cliente = ID_Cliente;
            filmeDAO.UpdateAluga(filme);

            return RedirectToAction("Index", "Cliente", clienteDAO.Read_By_ID(ID_Cliente));
        }

        //ALTERAR
        public ActionResult FilmesAlugados(int ID)
        {
            ViewBag.ID_Cliente = ID;
            return View(filmeDAO.Read_Rented(ID));
        }

        //ALTERAR
        public ActionResult ReturnCliente(int ID)
        {
            return RedirectToAction("Index", "Cliente", clienteDAO.Read_By_ID(ID));
        }


    }
}