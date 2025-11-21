using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class CategoriaController
    {
        public void AdicionarCategoria(Categoria categoria)
        {
            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            try
            {
                SqlCommand command = new(Categoria.INSERTCATEGORIA, connection);
                command.Parameters.AddWithValue("@Nome", categoria.Nome);
                command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                command.Parameters.AddWithValue("@Diaria", categoria.Diaria);

                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao adicionar categoria: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao adicionar categoria: " + e.Message);
            }
        }

        public void AtualizarCategoria(Categoria categoria, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                using SqlCommand command = new(Categoria.UPDATECATEGORIA, connection, transaction);

                command.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);
                command.Parameters.AddWithValue("@Nome", categoria.Nome);
                command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                command.Parameters.AddWithValue("@Diaria", categoria.Diaria);

                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao alterar categoria: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao alterar categoria: " + e.Message);
            }
        }

        public string BuscarCategoriaPorId(int id)
        {
            SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            try
            {
                SqlCommand command = new(Categoria.SELECTNOMECATEGORIAPORID, connection);
                command.Parameters.AddWithValue("@Id", id);

                string nomecategoria = String.Empty;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    nomecategoria = reader["Nome"].ToString() ?? string.Empty;
                }
                return nomecategoria;
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao buscar categoria por nome: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao buscar categoria por nome: " + e.Message);
            }
        }

    }
}
