using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class LocacaoController : ILocacaoController
    {
        public void AdicionarLocacao(Locacao locacao, int funcionarioID)
        {
            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                using SqlCommand command = new(Locacao.INSERTLOCACAO, connection, transaction);

                command.Parameters.AddWithValue("@ClienteID", locacao.ClienteID);
                command.Parameters.AddWithValue("@VeiculoID", locacao.VeiculoID);
                command.Parameters.AddWithValue("@DataLocacao", locacao.DataLocacao);
                command.Parameters.AddWithValue("@DataDevolucaoPrevista", locacao.DataDevolucaoPrevista);
                command.Parameters.AddWithValue("@DataDevolucaoReal", (object?)locacao.DataDevolucaoReal ?? DBNull.Value);
                command.Parameters.AddWithValue("@ValorDiaria", locacao.ValorDiaria);
                command.Parameters.AddWithValue("@ValorTotal", locacao.ValorTotal);
                command.Parameters.AddWithValue("@Multa", (object?)locacao.Multa ?? DBNull.Value);
                command.Parameters.AddWithValue("@Status", locacao.Status.ToString());

                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException e)
            {
                transaction.Rollback();
                throw new Exception("Erro no BD ao adicionar locacao mano -> " + e.Message);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("Erro inesperado ao adicionar locacao -> " + e.Message);
            }
        }
    }
}
