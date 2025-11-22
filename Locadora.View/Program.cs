using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;

namespace Locadora.View
{
    internal class Program
    {
        static void Main()
        {
            #region ClienteCRUD
            //ClienteController clienteController = new();
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
            #endregion

            #region VeiculoCRUD
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
            #endregion

            #region FuncionarioCRUD
            //FuncionarioController funcionarioController = new();
            //try
            //{

            // CRUD - Create
            //Funcionario funcionario = new("João Silva", "12345678900", "joao@email.com", 2500);
            //funcionarioController.AdicionarFuncionario(funcionario);

            // CRUD - READ Many
            //var funcionarios = funcionarioController.ListarTodosFuncionarios();
            //foreach (var f in funcionarios)
            //{
            //    Console.WriteLine(f);
            //    Console.WriteLine();
            //}

            // CRUD READ - One
            //var buscado = funcionarioController.BuscarFuncionarioPorCPF("12345678900");
            //Console.WriteLine(buscado);

            // CRUD - Update
            //Console.WriteLine(funcionarioController.BuscarFuncionarioPorCPF("12345678900"));
            //funcionarioController.AtualizarFuncionarioPorCPF(3000, "12345678900");
            //Console.WriteLine(funcionarioController.BuscarFuncionarioPorCPF("12345678900"));

            // CRUD - Delete
            //funcionarioController.DeletarFuncionarioPorCPF("12345678900");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            #endregion

            #region LocacaoCRUD
            LocacaoController locacaoController = new();
            try
            {
                // CRUD - Create
                //Locacao locacao = new(clienteID: 1, veiculoID: 2, valorDiaria: 150, diasLocacao: 5);
                //locacaoController.AdicionarLocacao(locacao, funcionarioID: 1);

                // CRUD - READ Many
                //var locacoes = locacaoController.ListarTodasLocacoes();
                //foreach (var locacao in locacoes)
                //{
                //    Console.WriteLine(locacao);
                //    Console.WriteLine();
                //}

                // CRUD - READ One
                //Console.WriteLine(locacaoController.BuscarLocacaoPorID(1));

                // CRUD - Update
                Console.WriteLine(locacaoController.BuscarLocacaoPorID(1005));
                locacaoController.FinalizarLocacao(1005, multa: 50);
                Console.WriteLine(locacaoController.BuscarLocacaoPorID(1005));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
        }
    }
}
