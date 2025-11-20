using Locadora.Models;
using Utils.Databases;
using Microsoft.Data.SqlClient;

namespace Locadora.Controller
{
    public class ClienteController
    {
        public void AdicionarCliente(Cliente cliente)
        {
            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            {
                try
                {
                    using SqlCommand command = new(Cliente.INSERTCLIENTE, connection, transaction);

                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);

                    cliente.SetClienteID((Convert.ToInt32(command.ExecuteScalar())));

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
            }
        }

        public List<Cliente> ListarClientes()
        {
            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            {
                try
                {
                    using SqlCommand command = new(Cliente.SELECTALLCLIENTES, connection, transaction);

                    using SqlDataReader reader = command.ExecuteReader();

                    List<Cliente> clientes = [];

                    while (reader.Read())
                    {
                        Cliente cliente = new(
                            reader["Nome"].ToString()!,
                            reader["Email"].ToString()!,
                            reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : null);

                        cliente.SetClienteID(Convert.ToInt32(reader["ClienteID"]));

                        clientes.Add(cliente);
                    }

                    reader.Close();

                    transaction.Commit();

                    return clientes;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao listar clientes: " + e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao listar clientes: " + e.Message);
                }
            }
        }

        public Cliente? BuscarClientePorEmail(string email) 
        {
            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            {
                try
                {
                    using SqlCommand command = new(Cliente.SELECTCLIENTEPOREMAIL, connection, transaction);

                    command.Parameters.AddWithValue("@Email", email);

                    using SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Cliente cliente = new(
                            reader["Nome"].ToString()!,
                            reader["Email"].ToString()!,
                            reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : null);
                        cliente.SetClienteID(Convert.ToInt32(reader["ClienteID"]));

                        return cliente;
                    }

                    reader.Close();

                    transaction.Commit();

                    return null;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao buscar cliente por email" + e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao buscar cliente por email" + e.Message);
                }
            }
        }

        public void AtualizarTelefoneCliente(string telefone, string email) 
        {
            var clienteEncontrado = BuscarClientePorEmail(email) ?? throw new Exception("Cliente não encontrado");

            clienteEncontrado.SetTelefone(telefone);

            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            {
                try
                {
                    using SqlCommand command = new(Cliente.UPDATEFONECLIENTE, connection, transaction);
                    command.Parameters.AddWithValue("@Telefone", clienteEncontrado.Telefone);
                    command.Parameters.AddWithValue("@IdCliente", clienteEncontrado.ClienteID);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar telefone do cliente: " + e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao atualizar telefone do cliente: " + e.Message);
                }
            }
        }

        public void DeletarCliente(string email)
        {
            var clienteEncontrado = BuscarClientePorEmail(email) ?? throw new Exception("Cliente não encontrado");

            using SqlConnection connection = new(ConnectionDB.GetConnectionString());
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            {
                try
                {
                    using SqlCommand command = new(Cliente.DELETECLIENTE, connection, transaction);

                    command.Parameters.AddWithValue("@Email", clienteEncontrado.Email);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao tentar deletar o cliente" + e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao tentar deletar o cliente" + e.Message);
                }
            }
        }
    }
}
