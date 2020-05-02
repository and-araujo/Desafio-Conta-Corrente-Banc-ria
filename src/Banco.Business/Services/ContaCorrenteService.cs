using Banco.Business.Interfaces;
using Banco.Business.Models;
using Banco.Business.Models.Base;
using System;
using System.Threading.Tasks;

namespace Banco.Business.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IContaCorrenteTransacaoService _contaCorrenteTransacaoService;
        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository,
                                    IContaCorrenteTransacaoService contaCorrenteTransacaoService)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _contaCorrenteTransacaoService = contaCorrenteTransacaoService;
        }

        public ContaCorrenteService()
        {
        }

        public async Task Depositar(int contaId, decimal valor)
        {
            ValidadorDeRegra.Novo()
                .Quando(valor <= 0, Resource.ValorMenorQueZero)
                .DispararExcecaoSeExistir();

            try
            {
                var contaOrigem = await _contaCorrenteRepository.ObterPorId(contaId);
                contaOrigem.SaldoAtual += valor;
                await _contaCorrenteRepository.Atualizar(contaOrigem);

                await RegistrarTransacao(valor, contaOrigem, TipoTransacao.Deposito);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task PagarConta(int contaId, decimal valor)
        {
            ValidadorDeRegra.Novo()
                .Quando(valor <= 0, Resource.ValorMenorQueZero)
                .DispararExcecaoSeExistir();
            try
            {
                var contaOrigem = await _contaCorrenteRepository.ObterPorId(contaId);
                contaOrigem.RetirarValorSaldo(valor);  
                await _contaCorrenteRepository.Atualizar(contaOrigem);

                await RegistrarTransacao(valor, contaOrigem, TipoTransacao.PagamentoConta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Retirar(int contaId, decimal valor)
        {
            ValidadorDeRegra.Novo()
               .Quando(valor <= 0, Resource.ValorMenorQueZero)
               .DispararExcecaoSeExistir();
            try
            {
                var contaOrigem = await _contaCorrenteRepository.ObterPorId(contaId);

                contaOrigem.RetirarValorSaldo(valor);
                await _contaCorrenteRepository.Atualizar(contaOrigem);
                
                await RegistrarTransacao(valor, contaOrigem, TipoTransacao.Retirada);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task RegistrarTransacao(decimal valor, ContaCorrente contaOrigem, TipoTransacao tipoTransacao)
        {
            ContaCorrenteTransacao transacao = new ContaCorrenteTransacao()
            {
                ContaCorrente = contaOrigem,
                DataTransacao = DateTime.Now,
                TipoTransacao = tipoTransacao,
                ValorTransacao = tipoTransacao != TipoTransacao.Deposito ? valor * (-1) : valor
            };
            await _contaCorrenteTransacaoService.Registrar(transacao);
        }

        public async Task Adicionar(ContaCorrente conta)
        {
            try
            {
                await _contaCorrenteRepository.Adicionar(conta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _contaCorrenteRepository?.Dispose();            
        }
    }
}
