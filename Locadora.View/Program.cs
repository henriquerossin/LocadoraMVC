using Locadora.Models;

namespace Locadora.View
{
    internal class Program
    {
        static void Main()
        {
            Cliente cliente = new("Henrique", "a@a.com");
            Documento documento = new(1, "RG", "123456789", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

            Console.WriteLine(cliente);
            Console.WriteLine(documento);
        }
    }
}
