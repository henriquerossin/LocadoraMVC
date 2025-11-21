using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    internal interface ILocacaoController
    {
        public void AdicionarLocacao(Locacao locacao, int funcionarioID);
    }
}
