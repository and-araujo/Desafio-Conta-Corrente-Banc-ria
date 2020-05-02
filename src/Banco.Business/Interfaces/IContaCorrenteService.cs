
using Banco.Business.Models;
using System;
using System.Threading.Tasks;

namespace Banco.Business.Interfaces
{
    public interface IContaCorrenteService : IDisposable
    {
        Task Adicionar(ContaCorrente conta);
        Task Depositar(int contaId, decimal valor);
        Task Retirar(int contaId, decimal valor);
        Task PagarConta(int contaId, decimal valor);
    }
}
