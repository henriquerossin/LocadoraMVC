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

            //VeiculoController veiculoController = new();

            //try
            //{
            //CRUD CREATE

            //Veiculo veiculo = new(1, "XYZ-9876", "Chevrolet", "S10", 2025, EStatusVeiculo.Disponivel.ToString());

            // CRUD READ MANY

            //veiculoController.AdicionarVeiculo(veiculo);
            //var veiculos = veiculoController.ListarTodosVeiculos();

            //foreach (var veiculo in veiculos)
            //{
            //    Console.WriteLine(veiculo);
            //}

            //CRUD READ ONE
            //var teste = veiculoController.BuscarVeiculoPlaca("XYZ-9876");
            //Console.WriteLine(teste);

            //CRUD UPDATE

            //Console.WriteLine(veiculoController.BuscarVeiculoPlaca("MNO7890"));
            //veiculoController.AtualizarStatusVeiculo(EStatusVeiculo.Manutencao.ToString(), "MNO7890");
            //Console.WriteLine(veiculoController.BuscarVeiculoPlaca("MNO7890"));

            //CRUD DELETE

            //veiculoController.DeletarVeiculo(1002);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

                LocacaoController locacaoController = new();
            try
            {
                //CRUD CREATE

                Locacao locacao = new(1, 1, 150.00m, 5);

                locacaoController.AdicionarLocacao(locacao, 1);
                Console.WriteLine("Locação adicionada com sucesso.");
                Console.WriteLine(locacao);

                // CRUD READ MANY

                //CRUD READ ONE

                //CRUD UPDATE



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
