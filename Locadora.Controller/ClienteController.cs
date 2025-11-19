using Locadora.Models;
using Utils.Databases;
using Microsoft.Data.SqlClient;

namespace Locadora.Controller
{
    public class ClienteController
    {
        public void AdicionarCliente(Cliente cliente)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            {
                try
                {
                    SqlCommand command = new(Cliente.INSERTCLIENTE, connection, transaction);

                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? /*null*/(object)DBNull.Value);

                    //cliente.setClienteID((Convert.ToInt32(command.ExecuteScalar()))); --> mesma coisa abaixo:
                    int clienteId = Convert.ToInt32(command.ExecuteScalar());

                    cliente.SetClienteID(clienteId);

                    transaction.Commit();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar cliente: " + e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao adicionar cliente: " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Cliente> ListarClientes()
        {
            SqlConnection connection = new(ConnectionDB.GetConnectionString());

            try
            {
                connection.Open();

                SqlCommand command = new(Cliente.SELECTALLCLIENTES, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Cliente> clientes = [];

                while (reader.Read())
                {
                    Cliente cliente = new(
                        reader["Nome"].ToString()!,
                        reader["Email"].ToString()!,
                        // lógica abaixo: "reader["Telefone"] é diferente de Nulo no bd? se sim, converte em string e pega (reader["Telefone"].ToString()), senão, add "null".
                        reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : null);

                    cliente.SetClienteID(Convert.ToInt32(reader["ClienteID"]));

                    clientes.Add(cliente);
                }
                return clientes;
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao listar clientes: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao listar clientes: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public Cliente BuscaClientePorEmail(string email) 
        {
            SqlConnection connection = new(ConnectionDB.GetConnectionString());

            connection.Open();

            try
            {
                SqlCommand command = new(Cliente.SELECTCLIENTEPOREMAIL, connection);

                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Cliente cliente = new(
                        reader["Nome"].ToString()!,
                        reader["Email"].ToString()!,
                        reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : null);
                    cliente.SetClienteID(Convert.ToInt32(reader["ClienteID"]));
                    return cliente;
                }
                return null;
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao buscar cliente por email" + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao buscar cliente por email" + e.Message);
            }
            finally
            {
                connection.Close(); 
            }
        }

        public void AtualizarTelefoneCliente(string telefone, string email) 
        {
            // Se o resultado for null (IsNull), lança a exceção; senão usa o valor retornado
            var clienteEncontrado = BuscaClientePorEmail(email) ?? throw new Exception();

            clienteEncontrado.SetTelefone(telefone);

            SqlConnection connection = new(ConnectionDB.GetConnectionString());

            connection.Open();

            try
            {
                SqlCommand command = new(Cliente.UPDATEFONECLIENTE, connection);
                command.Parameters.AddWithValue("@Telefone", clienteEncontrado.Telefone);
                command.Parameters.AddWithValue("@IdCliente", clienteEncontrado.ClienteID);
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao atualizar telefone do cliente: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao atualizar telefone do cliente: " + e.Message);
            }
            finally
            {
                connection.Close(); 
            }
        }
    }
}
