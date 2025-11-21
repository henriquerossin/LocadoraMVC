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

        public void AtualizarStatusVeiculo(string statusVeiculo)
        {
            throw new NotImplementedException();
        }
        
        public Veiculo BuscarVeiculoPlaca(string placa)
        {
            throw new NotImplementedException();
        }

        public void DeletarVeiculo(int idVeiculo)
        {
            throw new NotImplementedException();
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
