using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Locadora_Soares.Models;

namespace Locadora_Soares.Persistence
{
    public class ClienteDAO
    {
        public Cliente Login(Cliente cliente)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryLogin = "SELECT * FROM Cliente WHERE Login=@login AND Senha=@senha";
                try
                {
                    var ClienteLogin = conexao.QueryFirstOrDefault<Cliente>(queryLogin, cliente);
                    conexao.Close();
                    return ClienteLogin;

                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível realizar o login", e);
                }
            }

        }
        

        public void Create(Cliente cliente)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryCreate = "INSERT INTO Cliente (Nome, Login, Senha) VALUES (@nome, @login, @senha)";
                try
                {
                    conexao.Execute(queryCreate,cliente);
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível cadastrar o novo cliente",e);
                }
            }
        }

        public IEnumerable<Cliente> Read_All(){
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_All = "SELECT * FROM Cliente ORDER BY ID";
                try
                {
                    var result = conexao.Query<Cliente>(queryRead_All);
                    conexao.Close();
                    return result;

                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os clientes", e);
                }
            }

        }

        public Cliente Read_By_ID(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_By_ID = "SELECT * FROM Cliente WHERE ID=@id";
                try
                {
                    var result = conexao.QueryFirstOrDefault< Cliente >(queryRead_By_ID, new { ID = ID });
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar o cliente", e);
                }
            }
        }


        public void Delete(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryDelete = "DELETE FROM Cliente WHERE ID=@id";
                try
                {
                    conexao.Execute(queryDelete, new { ID = ID });
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível excluir o cliente", e);
                }
            }
        }
        public void Update(Cliente cliente)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryUpdate = "UPDATE Cliente SET Nome=@nome, Login=@login, Senha=@senha WHERE ID = @id";
                try
                {
                    conexao.Execute(queryUpdate, cliente);
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível editar o cliente", e);
                }
            }
        }


        //private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Locadora-Soares;Data Source=SOARESQS-PC\SQLEXPRESS;";
        private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Locadora-Soares;Data Source=GENIPABU\SQL2014;user=sa;password=adm123***";
    }
}