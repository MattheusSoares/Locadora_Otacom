using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Locadora_Soares.Models;

namespace Locadora_Soares.Persistence
{
    public class FilmeDAO
    {

        public void Create(Filme filme)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryCreate = "INSERT INTO Filme(Nome, Ano, Categoria) VALUES (@nome, @ano, @categoria)";
                try
                {
                    conexao.Execute(queryCreate, filme);
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível cadastrar o novo filme", e);
                }
            }
        }

        public IEnumerable<Filme> Read_All()
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_All = "SELECT * FROM Filme ORDER BY ID";
                try
                {
                    var result = conexao.Query<Filme>(queryRead_All);
                    conexao.Close();
                    return result;

                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os filmes", e);
                }
            }

        }

        public Filme Read_By_ID(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_By_ID = "SELECT * FROM Filme WHERE ID=@id";
                try
                {
                    var result = conexao.QueryFirstOrDefault<Filme>(queryRead_By_ID, new { ID = ID });
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar o filme", e);
                }
            }
        }

        public IEnumerable<Filme> Read_Available()
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_Available = "SELECT * FROM Filme WHERE ID_Cliente IS NULL ORDER BY ID";
                try
                {
                    var result = conexao.Query<Filme>(queryRead_Available);
                    conexao.Close();
                    return result;

                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os filmes", e);
                }
            }

        }

        public IEnumerable<Filme> Read_Rented(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_Rented = "SELECT * FROM Filme WHERE ID_Cliente=@id ORDER BY ID";
                try
                {
                    var result = conexao.Query<Filme>(queryRead_Rented, new { ID = ID });
                    conexao.Close();
                    return result;

                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os filmes", e);
                }
            }

        }


        public void Delete(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryDelete = "DELETE FROM Filme WHERE ID=@id";
                try
                {
                    conexao.Execute(queryDelete, new { ID = ID });
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível excluir o filme", e);
                }
            }
        }


        public void Update(Filme filme)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryUpdate = "UPDATE Filme SET Nome=@nome, Ano=@ano, Categoria=@categoria WHERE ID = @id";
                try
                {
                    conexao.Execute(queryUpdate, filme);
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível editar o filme", e);
                }
            }
        }

        public void Update_Rent(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryUpdate = "UPDATE Filme SET ID_Cliente = NULL WHERE ID = @id";
                try
                {
                    conexao.Execute(queryUpdate, new { ID = ID });
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível editar o filme", e);
                }
            }
        }
        public void UpdateAluga(Filme filme)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryUpdateAluga = "UPDATE Filme SET Nome=@nome, Ano=@ano, Categoria=@categoria, ID_Cliente=@id_cliente WHERE ID = @id";
                try
                {
                    conexao.Execute(queryUpdateAluga, filme);
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível alugar o filme", e);
                }
            }
        }

        private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Locadora-Soares;Data Source=GENIPABU\SQL2014;user=sa;password=adm123***";

    }
}