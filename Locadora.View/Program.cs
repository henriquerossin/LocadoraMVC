using Locadora.Controller;
using Locadora.Models;

namespace Locadora.View
{
    internal class Program
    {
        static void Main()
        {
            ClienteController clienteController = new();

            Cliente cliente = new("Pocoyo", "p@o.com.pocoyo");
            //Documento documento = new(1, "RG", "123456789", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

            Console.WriteLine(cliente);

            clienteController.AdicionarCliente(cliente);
        }
    }
}
