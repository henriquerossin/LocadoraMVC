using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.View
{
    internal class Program
    {
        static void Main()
        {
            Cliente cliente = new("Henrique", "a@a.com");
            //Documento documento = new(1, "RG", "123456789", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

            Console.WriteLine(cliente);

            SqlConnection connection = new(ConnectionDB.GetConnectionString());

            connection.Open();

            SqlCommand command = new(Cliente.INSERTCLIENTE, connection);

            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);

            //cliente.setClienteID((Convert.ToInt32(command.ExecuteScalar()))); --> mesma coisa abaixo:
            int clienteId = Convert.ToInt32(command.ExecuteScalar());
            cliente.setClienteID(clienteId);
        }
    }
}
