

using Banco.Business.Models;
using System;
using System.Threading.Tasks;

namespace Banco.Business.Interfaces
{
    public interface IContaCorrenteTransacaoService : IDisposable
    {
        Task Registrar(ContaCorrenteTransacao conta);
        Task Buscar(ContaCorrente conta);
    }
}
