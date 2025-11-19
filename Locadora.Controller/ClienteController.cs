using Locadora.Models;
using Utils.Databases;
using Microsoft.Data.SqlClient;

namespace Locadora.Controller
{
    public class ClienteController
    {
        public void AdicionarCliente(Cliente cliente)
        {
            SqlConnection connection = new(ConnectionDB.GetConnectionString());

            connection.Open();

            SqlCommand command = new(Cliente.INSERTCLIENTE, connection);

            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? /*null*/(object)DBNull.Value);

            //cliente.setClienteID((Convert.ToInt32(command.ExecuteScalar()))); --> mesma coisa abaixo:
            int clienteId = Convert.ToInt32(command.ExecuteScalar());
            cliente.setClienteID(clienteId);

            connection.Close();
        }

        public List<Cliente> ListarClientes()
        {
            SqlConnection connection = new(ConnectionDB.GetConnectionString());

            connection.Open();

            SqlCommand command = new(Cliente.SELECTALLCLIENTES, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Cliente> clientes = new();

            while (reader.Read())
            {
                Cliente cliente = new(
                    reader["Nome"].ToString()!, 
                    reader["Email"].ToString()!,
                    // lógica abaixo: "reader["Telefone"] é diferente de Nulo no bd? se sim, converte em string e pega (reader["Telefone"].ToString()), senão, add "null".
                    reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : null);

                cliente.setClienteID(Convert.ToInt32(reader["ClienteID"]));

                clientes.Add(cliente);
            }

            connection.Close();

            return clientes;
        }
    }
}
