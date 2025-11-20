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
            //Cliente cliente = new("Pocoyo suave4", "p@o.com.pocoyosuave4");
            //Documento documento = new(1, "RG", "11111", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

            //try
            //{
            //    clienteController.AdicionarCliente(cliente);
            //    Console.WriteLine("Cliente adicionado com sucesso.");
            //}
            //catch (Exception e)
            //{
            //    if (e.Message.Contains("Violation of UNIQUE KEY"))
            //        Console.WriteLine("Não é possível adicionar um novo cliente com o mesmo email!");
            //}

            // CREATE - READ Many
            try
            {
                var listaDeClientes = clienteController.ListarClientes();
                Console.WriteLine("Lista de clientes");
                Console.WriteLine();
                foreach (var c in listaDeClientes)
                {
                    Console.WriteLine(c);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um problema na View durante a leitura da lista de clientes " + e.Message);
            }

            // CREATE - READ One
            //try
            //{
            //    Console.WriteLine(clienteController.BuscarClientePorEmail("p@o.com.pocoyosuave1"));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Houve um problema na View durante a leitura das informações do cliente " + e.Message);
            //}

            // CREATE - UPDATE
            //try
            //{
            //    clienteController.AtualizarTelefoneCliente("11211-1111", "joao.silva@email.com");
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
            //    clienteController.DeletarCliente("p@o.com.pocoyoBrabao");
            //    Console.WriteLine("Cliente deletado com sucesso");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Houve um problema na View ao tentar deletar o cliente " + e.Message);
            //}
        }
    }
}
