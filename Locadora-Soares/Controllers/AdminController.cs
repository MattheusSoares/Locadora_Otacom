﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locadora_Soares.Models;
using Locadora_Soares.Persistence;
using Locadora_Soares.ViewModel;

namespace Locadora_Soares.Persistence
{
    public class AdminController : Controller
    {
        private AdminDAO adminDAO = new AdminDAO();
        private ClienteDAO clienteDAO = new ClienteDAO();
        private FilmeDAO filmeDAO = new FilmeDAO();
        private AlugaDAO alugaDAO = new AlugaDAO();

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.user_layout = "inicio";
            ViewBag.title_welcome = "Bem-vindo a Área Administrativa da Locadora Soares, ";
            ViewBag.title = "por favor, insira suas credenciais";
            ViewBag.session_status = "nao_logado";

            return View();
        }

        public ActionResult Login(string login, string senha)
        {
            Admin admin = new Admin(login,senha);
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
            ViewBag.user_layout = "inicio";
            ViewBag.title_welcome = "Erro de credenciais";
            ViewBag.title = "";
            ViewBag.session_status = "nao_logado";

            return View();
        }

        public ActionResult AdminMain()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            IEnumerable<TopFilmeLocacoes> filmesMaisAlugados = alugaDAO.Read_Top_Movies_Rented();

            IEnumerable<FilmesAlugados> filmesAlugados = alugaDAO.Read_Last_Movies_Rented();
            IEnumerable<FilmesAlugados> filmesDevolvidos = alugaDAO.Read_Last_Movies_Returned();

            ViewBag.filmesAlugados = filmesAlugados;
            ViewBag.filmesDevolvidos = filmesDevolvidos;

            List<int> valores = new List<int>();
            List<string> labels = new List<string>();

            foreach (var f in filmesMaisAlugados) {
                labels.Add(f.Filme);
                valores.Add(f.Locacoes);
            }

            ViewBag.labels = labels;
            ViewBag.valores = valores;

            return View();
        }

        public ActionResult CadastrarCliente()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View();
        }
        public ActionResult CreateCliente(string nome, string login, string senha)
        {
            Cliente cliente = new Cliente(nome,login,senha);
            clienteDAO.Create(cliente);
            return RedirectToAction("CadastroClienteSucesso", "Admin");
        }
        public ActionResult CadastroClienteSucesso()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View();
        }

        public ActionResult ListarCliente()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View(clienteDAO.Read_All());
        }

        public ActionResult EditarCliente(int ID)
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View(clienteDAO.Read_By_ID(ID));
        }

        public ActionResult UpdateCliente(int ID, string nome, string login, string senha)
        {
            Cliente cliente = new Cliente(ID, nome,login,senha);
            clienteDAO.Update(cliente);
            return RedirectToAction("EditarClienteSucesso", "Admin");
        }

        public ActionResult EditarClienteSucesso()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View();
        }

        public ActionResult ExcluirCliente(int ID)
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";



            IEnumerable<Filme> filmes = alugaDAO.Read_Rented_by_Cliente_by_ID(ID);

            foreach (var f in filmes)
            {
                filmeDAO.Update_to_Available(f.ID);
            }

            alugaDAO.Delete_Client(ID);
            clienteDAO.Delete(ID);
            return View();
        }


        public ActionResult CadastrarFilme()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View();
        }

        public ActionResult CreateFilme(string nome, int ano, string categoria)
        {
            Filme filme = new Filme(nome,ano,categoria);
            filmeDAO.Create(filme);
            return RedirectToAction("CadastroFilmeSucesso", "Admin");
        }

        public ActionResult CadastroFilmeSucesso()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View();
        }

        public ActionResult ListarFilme()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View(filmeDAO.Read_All());
        }

        public ActionResult EditarFilme(int ID)
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View(filmeDAO.Read_By_ID(ID));
        }

        public ActionResult UpdateFilme(int ID, string nome, int ano, string categoria)
        {
            Filme filme = new Filme(ID,nome,ano,categoria);
            filmeDAO.Update(filme);
            return RedirectToAction("EditarFilmeSucesso", "Admin");
        }

        public ActionResult EditarFilmeSucesso()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            return View();
        }

        public ActionResult ExcluirFilme(int ID)
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            alugaDAO.Delete_Movie(ID);   
            filmeDAO.Delete(ID);
            return View();
        }

        public ActionResult ListarFilmesCliente(int ID)
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            Cliente cliente = clienteDAO.Read_By_ID(ID);

            ViewBag.ID_Cliente = cliente.ID;
            return View(alugaDAO.Read_Rented_by_Cliente_by_ID(ID));
        }
 
        
        public ActionResult DevolucaoFilme(int ID_Filme, int ID_Cliente)
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            ViewBag.ID_Cliente = ID_Cliente;

            Aluga aluga = new Aluga(ID_Cliente, ID_Filme);

            alugaDAO.Update_to_Available(aluga);
            filmeDAO.Update_to_Available(ID_Filme);
            return View();
        }

        public ActionResult RelatorioFilmesAlugados()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            IEnumerable<FilmesAlugados> filmesAlugados = alugaDAO.Read_Rented_by_Cliente();

            return View(filmesAlugados);
        }

        public ActionResult RelatorioTopClientesLocadores()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            IEnumerable<TopClienteLocacoes> topClienteLocacoes = alugaDAO.Read_Top_Client_Renters();

            return View(topClienteLocacoes);
        }

        public ActionResult RelatorioTopFilmesAlugados()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            IEnumerable<TopFilmeLocacoes> topFilmeLocacoes = alugaDAO.Read_Top_Movies_Rented();

          
            return View(topFilmeLocacoes);
        }

        public ActionResult RelatorioUltimasLocacoes()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            IEnumerable<FilmesAlugados> filmesAlugados = alugaDAO.Read_Last_Movies_Rented();

            return View(filmesAlugados);
        }

        public ActionResult RelatorioUltimasDevolucoes()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            IEnumerable<FilmesAlugados> filmesAlugados = alugaDAO.Read_Last_Movies_Returned();

            return View(filmesAlugados);
        }



        public ActionResult GraficoTopFilmesAlugados()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            IEnumerable<TopFilmeLocacoes> filmesMaisAlugados = alugaDAO.Read_Top_Movies_Rented();

            List<int> valores = new List<int>();
            List<string> labels = new List<string>();

            foreach (var f in filmesMaisAlugados)
            {
                labels.Add(f.Filme);
                valores.Add(f.Locacoes);
            }

            ViewBag.labels = labels;
            ViewBag.valores = valores;

            return View();
        }


        public ActionResult GraficoTopClientesLocadores()
        {
            ViewBag.user_layout = "admin";
            ViewBag.title_welcome = "Olá, ";
            ViewBag.title = "Bem-vindo Administrador";
            ViewBag.session_status = "logado";

            IEnumerable<TopClienteLocacoes> topClienteLocacoes = alugaDAO.Read_Top_Client_Renters();

            List<int> valores = new List<int>();
            List<string> labels = new List<string>();

            foreach (var f in topClienteLocacoes)
            {
                labels.Add(f.Cliente);
                valores.Add(f.Locacoes);
            }

            ViewBag.labels = labels;
            ViewBag.valores = valores;

            return View();
        }



    }
}