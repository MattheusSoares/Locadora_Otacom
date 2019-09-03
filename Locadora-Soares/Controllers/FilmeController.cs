using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locadora_Soares.Models;
using Locadora_Soares.Persistence;

namespace Locadora_Soares.Controllers
{
    public class FilmeController : Controller
    {
        private FilmeDAO DAO = new FilmeDAO();

        // GET: Filme
        public ActionResult Index()
        {
            return View();
        }

        



    }
}