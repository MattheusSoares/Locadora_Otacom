using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Locadora_Soares.Models;

namespace Locadora_Soares.Persistence
{
    public class AdminDAO
    {
        public Admin LoginSU(Admin admin)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryLogin = "SELECT * FROM Admin WHERE Login=@login AND Senha=@senha";
                try
                {
                    var AdminLogin = conexao.QueryFirstOrDefault<Admin>(queryLogin, admin);
                    conexao.Close();
                    return AdminLogin;
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar o administrador", e);
                }
            }

        }


        //private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Locadora-Soares;Data Source=SOARESQS-PC\SQLEXPRESS;";
        private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Locadora-Soares;Data Source=GENIPABU\SQL2014;user=sa;password=adm123***";

    }
}