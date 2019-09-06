using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Locadora_Soares.Models;
using Locadora_Soares.ViewModel;

namespace Locadora_Soares.Persistence
{
    public class AlugaDAO
    {
        public void Create(Aluga aluga)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryCreate = "INSERT INTO Aluga (ID_Cliente, ID_Filme, Horario, Devolvido) " +
                    "VALUES (@id_cliente, @id_filme, @horario, 2)";
                try
                {
                    conexao.Execute(queryCreate, aluga);
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível cadastrar o novo aluguel", e);
                }
            }
        }

        public IEnumerable<Filme> Read_Rented_by_Cliente_by_ID(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_Rented_by_Cliente = "SELECT F.* FROM Filme F INNER JOIN Aluga A " +
                    "ON A.ID_Filme = F.ID " +
                    "AND A.ID_Cliente = @id " +
                    "WHERE F.Disponivel = 2 AND A.Devolvido = 2";
                try
                {
                    var result = conexao.Query<Filme>(queryRead_Rented_by_Cliente, new { ID = ID });
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os filmes alugados do cliente", e);
                }
            }
        }

        public void Update_to_Available(Aluga aluga)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryUpdate = "UPDATE Aluga SET Devolvido = 1 WHERE ID_Cliente = @id_cliente AND ID_Filme = @id_filme";
                try
                {
                    conexao.Execute(queryUpdate, aluga);
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível devolver o filme", e);
                }
            }
        }
        public void Delete_Movie(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryDelete_Movie = "DELETE FROM Aluga WHERE ID_Filme = @id";
                try
                {
                    conexao.Execute(queryDelete_Movie, new { id = ID});
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível remover o filme de aluguel", e);
                }
            }
        }

        public void Delete_Client(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryDelete_Client = "DELETE FROM Aluga WHERE ID_Cliente = @id";
                try
                {
                    conexao.Execute(queryDelete_Client, new { id = ID });
                    conexao.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível remover o cliente de aluguel", e);
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////RELATÓRIOS///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IEnumerable<FilmesAlugados> Read_Rented_by_Cliente()
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_Rented_by_Cliente = "SELECT C.ID as ID_Cliente, C.Nome AS Cliente, F.ID AS ID_Filme, F.Nome AS Filme, A.Horario  " +
                    "FROM Filme F " +
                    "INNER JOIN Aluga A " +
                    "ON A.ID_Filme = F.ID " +
                    "INNER JOIN Cliente C " +
                    "ON A.ID_Cliente = C.ID " +
                    "WHERE F.Disponivel = 2 AND A.Devolvido = 2";
                try
                {
                    var result = conexao.Query<FilmesAlugados>(queryRead_Rented_by_Cliente);
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os filmes alugados por clientes", e);
                }
            }
        }


        public IEnumerable<TopClienteLocacoes> Read_Top_Client_Renters()
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_Top_Client_Renters = "SELECT TOP 5 C.Nome AS Cliente, COUNT(A.ID_Cliente) AS  Locacoes " +
                    "FROM Cliente C " +
                    "INNER JOIN Aluga A " +
                    "ON A.ID_Cliente = C.ID " +
                    "GROUP BY C.Nome " +
                    "ORDER BY Locacoes DESC";
                try
                {
                    var result = conexao.Query<TopClienteLocacoes>(queryRead_Top_Client_Renters);
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os clientes mais locadores", e);
                }
            }
        }

        public IEnumerable<TopFilmeLocacoes> Read_Top_Movies_Rented()
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_Top_Movies_Rented = "SELECT TOP 5 F.Nome AS Filme, COUNT(A.ID_Filme) AS Locacoes " +
                    "FROM Filme F " +
                    "INNER JOIN Aluga A " +
                    "ON A.ID_Filme = F.ID " +
                    "GROUP BY F.Nome " +
                    "ORDER BY Locacoes DESC";
                try
                {
                    var result = conexao.Query<TopFilmeLocacoes>(queryRead_Top_Movies_Rented);
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os clientes mais locadores", e);
                }
            }
        }

        public IEnumerable<FilmesAlugados> Read_Last_Movies_Returned()
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_Last_Movies_Returned = "SELECT TOP 5 C.Nome AS Cliente, F.Nome AS Filme, A.Horario FROM Aluga A " +
                    "INNER JOIN Filme F " +
                    "ON A.ID_Filme = F.ID " +
                    "INNER JOIN Cliente C " +
                    "ON A.ID_Cliente = C.ID " +
                    "WHERE A.Devolvido = 1 " +
                    "ORDER BY A.Horario DESC";
                try
                {
                    var result = conexao.Query<FilmesAlugados>(queryRead_Last_Movies_Returned);
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os últimos filmes devolvidos", e);
                }
            }
        }

        public IEnumerable<FilmesAlugados> Read_Last_Movies_Rented()
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_Last_Movies_Rented = "SELECT TOP 5 C.Nome AS Cliente, F.Nome AS Filme, A.Horario FROM Aluga A " +
                    "INNER JOIN Filme F " +
                    "ON A.ID_Filme = F.ID " +
                    "INNER JOIN Cliente C " +
                    "ON A.ID_Cliente = C.ID " +
                    "WHERE A.Devolvido = 2 " +
                    "ORDER BY A.Horario DESC";
                try
                {
                    var result = conexao.Query<FilmesAlugados>(queryRead_Last_Movies_Rented);
                    conexao.Close();
                    return result;
                }
                catch (Exception e)
                {

                    throw new Exception("Não foi possível retornar os últimos filmes alugados", e);
                }
            }
        }



        private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Locadora-Soares;Data Source=GENIPABU\SQL2014;user=sa;password=adm123***";

    }
}