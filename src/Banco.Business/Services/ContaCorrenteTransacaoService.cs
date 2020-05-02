
using System;
using System.Threading.Tasks;
using Banco.Business.Interfaces;
using Banco.Business.Models;

namespace Banco.Business.Services
{
    public class ContaCorrenteTransacaoService : IContaCorrenteTransacaoService
    {
        private readonly IContaCorrenteTransacaoRepository _contaCorrenteTransacaoRepository;
        public ContaCorrenteTransacaoService(IContaCorrenteTransacaoRepository contaCorrenteTransacaoRepository)
        {
            _contaCorrenteTransacaoRepository = contaCorrenteTransacaoRepository;
        }
        public async Task Registrar(ContaCorrenteTransacao conta)
        {
            try
            {                
                await _contaCorrenteTransacaoRepository.Adicionar(conta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Buscar(ContaCorrente conta)
        {
            try
            {
                await _contaCorrenteTransacaoRepository.Buscar(c => c.ContaCorrente.Id == conta.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public void Dispose()
        {
            _contaCorrenteTransacaoRepository?.Dispose();
        }
    }
}
