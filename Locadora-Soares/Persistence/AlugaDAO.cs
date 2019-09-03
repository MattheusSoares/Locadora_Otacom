using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Locadora_Soares.Models;

namespace Locadora_Soares.Persistence
{
    public class AlugaDAO
    {

        private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Locadora-Soares;Data Source=GENIPABU\SQL2014;user=sa;password=adm123***";

    }
}