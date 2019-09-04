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
        public void Create(Aluga aluga)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryCreate = "INSERT INTO Aluga (ID_Cliente, ID_Filme, Horario, Devolvido) VALUES (@id_cliente, @id_filme, @horario, 2)";
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

        public IEnumerable<Filme> Read_Rented_by_Cliente(int ID)
        {
            using (var conexao = new SqlConnection(connStr))
            {
                String queryRead_Rented_by_Cliente = "SELECT F.* FROM Filme F INNER JOIN Aluga A ON A.ID_Filme = F.ID AND A.ID_Cliente = @id WHERE F.Disponivel = 2 AND A.Devolvido = 2";
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


        /*Realizar relatórios:
         * Top 10 filmes mais alugados
         * Últimos 10 filmes alugados
         * 
         * Filmes alugados
         * Filmes devolvidos recentemente
         * Top 10 filmes menos alugados
         * */


        private static readonly string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Locadora-Soares;Data Source=GENIPABU\SQL2014;user=sa;password=adm123***";

    }
}