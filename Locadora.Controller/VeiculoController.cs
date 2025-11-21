using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class VeiculoController : IVeiculoController
    {
        public void AdicionarVeiculo(Veiculo veiculo)
        {
            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                using SqlCommand command = new(Veiculo.INSERTVEICULO, connection, transaction);
                command.Parameters.AddWithValue("@CategoriaID", veiculo.CategoriaID);
                command.Parameters.AddWithValue("@Placa", veiculo.Placa);
                command.Parameters.AddWithValue("@Marca", veiculo.Marca);
                command.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                command.Parameters.AddWithValue("@Ano", veiculo.Ano);
                command.Parameters.AddWithValue("@StatusVeiculo", veiculo.StatusVeiculo);

                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException e)
            {
                transaction.Rollback();
                throw new Exception("Deu ruim aqui na hora de adicionar o veículo no bd, mano -> " + e.Message);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("Deu ruim aqui na hora de adicionar o veículo, mano -> " + e.Message);
            }
        }

        public void AtualizarStatusVeiculo(string statusVeiculo, string placa)
        {
            Veiculo veiculo = BuscarVeiculoPlaca(placa) ?? throw new Exception("não foi possível encontrar o veículo");

            SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                SqlCommand command = new(Veiculo.UPDATESTATUSVEICULO, connection, transaction);
                try
                { 
                    command.Parameters.AddWithValue("@StatusVeiculo", statusVeiculo);
                    command.Parameters.AddWithValue("@IdVeiculo", veiculo.VeiculoID);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("Deu ruim aqui na hora de atualizar o status do veículo no bd, mano -> " + e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Deu ruim aqui na hora de atualizar o status do veículo, mano -> " + e.Message);
                }
            }
        }
        
        public Veiculo BuscarVeiculoPlaca(string placa)
        {
            CategoriaController categoriaController = new();

            Veiculo veiculo = null!;

            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using SqlCommand command = new(Veiculo.SELECTVEICULOBYPLACA, connection);
            try
            {
                command.Parameters.AddWithValue("@Placa", placa);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        veiculo = new(
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetInt32(5),
                            reader.GetString(6));

                        veiculo.SetVeiculoID(reader.GetInt32(0));

                        veiculo.SetNomeCategoria(categoriaController.BuscarCategoriaPorId(veiculo.CategoriaID));
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Deu pau na hora de mostrar o veículo do bd, mano -> " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Deu pau na hora de mostrar o veículo, mano -> " + e.Message);
            }

            return veiculo ?? throw new Exception("Veículo não encontrado");
        }

        public void DeletarVeiculo(int idVeiculo)
        {
            SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();


            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                SqlCommand command = new(Veiculo.DELETEVEICULO, connection, transaction);
                try
                {
                    command.Parameters.AddWithValue("@IdVeiculo", idVeiculo);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("Deu ruim aqui na hora de deletar o veículo no bd, mano -> " + e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Deu ruim aqui na hora de deletar o veículo, mano -> " + e.Message);
                }
            }
        }

        public List<Veiculo> ListarTodosVeiculos()
        {
            List<Veiculo> veiculos = new();
            CategoriaController categoriaController = new();

            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using SqlCommand command = new(Veiculo.SELECTALLVEICULOS, connection);
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Veiculo veiculo = new(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4),
                            reader.GetString(5));

                        veiculo.SetNomeCategoria(categoriaController.BuscarCategoriaPorId(veiculo.CategoriaID));
                        veiculos.Add(veiculo);
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Deu pau na hora de mostrar os veículos do bd, mano -> " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Deu pau na hora de mostrar os veículos, mano -> " + e.Message);
            }

            return veiculos;
        }
    }
}
