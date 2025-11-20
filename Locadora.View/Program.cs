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
            try
            {
                var listaDeClientes = clienteController.ListarClientes();

                foreach (var c in listaDeClientes)
                {
                    Console.WriteLine(c);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um problema na View durante a leitura da lista de clientes " + e.Message);
            }

            // CREATE - UPDATE
            //try
            //{
            //    clienteController.AtualizarTelefoneCliente("12345-1234", "joao.silva@email.com");
            //    Console.WriteLine(clienteController.BuscarClientePorEmail("joao.silva@email.com"));
            //    Console.WriteLine("Atualização efetuada com sucesso.");
            //}
            //catch (Exception e)
            //{
            //    throw new Exception("Houve um problema na View ao tentar executar um update " + e.Message);
            //}

            // CREATE - DELETE 
            //try
            //{
            //clienteController.DeletarCliente("p@o.com.pocoyoBrabao3");
            //    Console.WriteLine("Cliente deletado com sucesso");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Houve um problema na View ao tentar deletar o cliente " + e.Message); 
            //} 
        }
    }
}
