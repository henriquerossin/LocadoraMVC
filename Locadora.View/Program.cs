using Locadora.Controller;
using Locadora.Models;

namespace Locadora.View
{
    internal class Program
    {
        static void Main()
        {
            ClienteController clienteController = new();

            // CREATE - CREATE
            //Cliente cliente = new("Pocoyo brabao6", "p@o.com.pocoyoBrabao6");
            //Documento documento = new(1, "RG", "123456789", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

            //try
            //{
            //    clienteController.AdicionarCliente(cliente);
            //}
            //catch (Exception e)
            //{
            //    if (e.Message.Contains("Violation of UNIQUE KEY"))
            //        Console.WriteLine("Não é possível adicionar um novo cliente com o mesmo email!");
            //}

            // CREATE - READ
            //try
            //{
            //    var listaDeClientes = clienteController.ListarClientes();

            //    foreach (var c in listaDeClientes)
            //    {
            //        Console.WriteLine(c);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            // CREATE - UPDATE
            //clienteController.AtualizarTelefoneCliente("99999-9999", "joao.silva@email.com");

            // CREATE - DELETE 

        }
    }
}
