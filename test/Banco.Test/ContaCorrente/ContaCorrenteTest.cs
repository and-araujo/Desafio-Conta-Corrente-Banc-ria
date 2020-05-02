using Banco.Business.Interfaces;
using Banco.Business.Models;
using Banco.Business.Models.Base;
using Banco.Business.Services;
using Bogus;
using ExpectedObjects;
using System;
using Xunit;

namespace Banco.Test
{
    public class ContaCorrenteTest
    {
        private readonly int _agencia;
        private readonly int _numeroConta;
        private readonly int _digitoConta;
        private readonly DateTime _dataAbertura;
        private readonly decimal _saldoAtual;
        private readonly Faker _faker;

        private readonly IContaCorrenteService _contaCorrenteService;
        public ContaCorrenteTest()
        {
            _faker = new Faker();

            _agencia = _faker.Random.Int(1, 9999);
            _numeroConta = _faker.Random.Int(1, 999999);
            _digitoConta = _faker.Random.Int(1,1);
            _saldoAtual = _faker.Random.Decimal(100, 1000);
            _dataAbertura = DateTime.Now;

            _contaCorrenteService = new ContaCorrenteService();
        }

        [Fact]
        public void DeveCriarContaCorrente()
        {
            var contaEsperado = new
            {
                Agencia = _agencia,
                NumeroConta = _numeroConta,
                DigitoConta = _digitoConta,
                DataAbertura = _dataAbertura,
                SaldoAtual = _saldoAtual
            };

            var conta = new ContaCorrente(contaEsperado.Agencia, contaEsperado.NumeroConta, contaEsperado.DigitoConta, contaEsperado.DataAbertura, contaEsperado.SaldoAtual);

            contaEsperado.ToExpectedObject().ShouldMatch(conta);
        }

        [Theory]
        [InlineData(0.00)]
        [InlineData(-0.01)]
        public async void NaoDeveDepositarValorMenorIgualAZero(decimal valorInvalido)
        {
            await Assert.ThrowsAsync<ExcecaoDeDominio>(()=> _contaCorrenteService.Depositar(1, valorInvalido));
        }

        [Theory]
        [InlineData(0.00)]
        [InlineData(-0.01)]
        public async void NaoDeveRetirarValorMenorIgualAZero(decimal valorInvalido)
        {
            await Assert.ThrowsAsync<ExcecaoDeDominio>(() => _contaCorrenteService.Retirar(1, valorInvalido));
        }

        [Theory]
        [InlineData(0.00)]
        [InlineData(-0.01)]
        public async void NaoDevePagarContaValorMenorIgualAZero(decimal valorInvalido)
        {
            await Assert.ThrowsAsync<ExcecaoDeDominio>(() => _contaCorrenteService.PagarConta(1, valorInvalido));
        }

        [Fact]
        public void NaoDeveRetirarValorMaiorQueOSaldo()
        {
            var conta = new ContaCorrente(_agencia, _numeroConta, _digitoConta, _dataAbertura, 100);
            Assert.Throws<ExcecaoDeDominio>(() => conta.RetirarValorSaldo(100.01m));
        }

        [Fact]
        public void NaoDevePagarContaDeValorMaiorQueOSaldo()
        {
            var conta = new ContaCorrente(_agencia, _numeroConta, _digitoConta, _dataAbertura, 100);
            Assert.Throws<ExcecaoDeDominio>(() => conta.RetirarValorSaldo(100.01m));
        }
    }
}
