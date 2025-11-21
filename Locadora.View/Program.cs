using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;

namespace Locadora.View
{
    internal class Program
    {
        static void Main()
        {
            ClienteController clienteController = new();

            //  CREATE - CREATE
            // Cliente cliente = new("Tarnished", "EldenRing.com.LiurniaDosLagos");
            //Documento documento = new("CPF", "2022", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

            // try
            // {
            //     clienteController.AdicionarCliente(cliente, documento);
            //     Console.WriteLine("Cliente adicionado com sucesso.");
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            // }

            //  CREATE - READ Many
            //try
            //{
            //    var listaDeClientes = clienteController.ListarClientes();
            //    Console.WriteLine("Lista de clientes");
            //    Console.WriteLine();
            //    foreach (var c in listaDeClientes)
            //    {
            //        Console.WriteLine(c);
            //        Console.WriteLine();
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //  CREATE - READ One
            //try
            //{
            //    Console.WriteLine(clienteController.BuscarClientePorEmail("EldenRing.com.LiurniaDosLagos"));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //
            //  CREATE - UPDATE
            // try
            // {
            //     clienteController.AtualizarTelefoneCliente("11211-1111", "joao.silva@email.com");
            //     Console.WriteLine(clienteController.BuscarClientePorEmail("joao.silva@email.com"));
            //     Console.WriteLine("Atualização efetuada com sucesso.");
            // }
            // catch (Exception e)
            // {
            //     throw new Exception(e.Message);
            // }

            //Documento documento = new("CPF", "2022", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

            //try
            //{
            //    clienteController.AtualizarDocumentoCliente("EldenRing.com.LiurniaDosLagos", documento);
            //    Console.WriteLine(clienteController.BuscarClientePorEmail("EldenRing.com.LiurniaDosLagos"));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //CREATE - DELETE
            //try
            //{
            //    clienteController.DeletarCliente("p@o.com.pocoyosuave4Documento345");
            //    Console.WriteLine("Cliente deletado com sucesso");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}



            //CategoriaController categoriaController = new();

            //Categoria categoria = new("Pesado", 250.00m, "Veículo espacial kk");
            //categoriaController.AdicionarCategoria(categoria);

            //Categoria categoria2 = new("Levinho", 250.00m, "Veículo espacial kk");
            //categoriaController.AdicionarCategoria(categoria2);

            VeiculoController veiculoController = new();

            try
            {
                //Veiculo veiculo = new(1, "XYZ-9876", "Chevrolet", "S10", 2025, EStatusVeiculo.Disponivel.ToString());
                //veiculoController.AdicionarVeiculo(veiculo);
                var veiculos = veiculoController.ListarTodosVeiculos();

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
