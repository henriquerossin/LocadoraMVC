using Locadora.Models;

namespace Locadora.Controller.Interfaces
{
    public interface IVeiculoController
    {
        public void AdicionarVeiculo(Veiculo veiculo);

        public List<Veiculo> ListarTodosVeiculos();

        public Veiculo BuscarVeiculoPlaca(string placa);

        public void AtualizarStatusVeiculo(string statusVeiculo);

        public void DeletarVeiculo(int idVeiculo);
    }
}
