using Locadora.Models;
using Microsoft.Data.SqlClient;

namespace Locadora.Controller
{
    internal class DocumentoController
    {
        public void AdicionarDocumento(Documento documento, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                using SqlCommand command = new(Documento.INSERTDOCUMENTO, connection, transaction);

                command.Parameters.AddWithValue("@ClienteID", documento.ClienteID);
                command.Parameters.AddWithValue("@TipoDocumento", documento.TipoDocumento);
                command.Parameters.AddWithValue("@Numero", documento.Numero);
                command.Parameters.AddWithValue("@DataEmissao", documento.DataEmissao);
                command.Parameters.AddWithValue("@DataValidade", documento.DataValidade);

                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao adicionar documento: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao adicionar documento: " + e.Message);
            }
        }

        public void AtualizarDocumento(Documento documento, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                using SqlCommand command = new(Documento.UPDATEDOCUMENTO, connection, transaction);

                command.Parameters.AddWithValue("@IdCliente", documento.ClienteID);
                command.Parameters.AddWithValue("@TipoDocumento", documento.TipoDocumento);
                command.Parameters.AddWithValue("@Numero", documento.Numero);
                command.Parameters.AddWithValue("@DataEmissao", documento.DataEmissao);
                command.Parameters.AddWithValue("@DataValidade", documento.DataValidade);

                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao alterar documento: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao alterar documento: " + e.Message);
            }
        }
    }
}
