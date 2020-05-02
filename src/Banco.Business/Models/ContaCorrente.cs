
using Banco.Business.Models.Base;
using System;
using System.Collections.Generic;

namespace Banco.Business.Models
{
    public class ContaCorrente : Entity
    {
        public int Agencia { get; set; }
        public int NumeroConta { get; set; }
        public int DigitoConta { get; set; }
        public DateTime DataAbertura { get; set; }
        public decimal SaldoAtual { get; set; }
        /* EF Relations */
        public IEnumerable<ContaCorrenteTransacao> Transacoes { get; set; }

        public ContaCorrente() { }

        public ContaCorrente(int agencia, int numeroConta, int digitoConta, DateTime dataAbertura, decimal saldoAtual)
        {
            ValidadorDeRegra.Novo()
                .Quando(dataAbertura < DateTime.Now.Date, Resource.DataInvalida)
                .Quando(saldoAtual < 0, Resource.ValorMenorQueZero)
                .DispararExcecaoSeExistir();

            Agencia = agencia;
            NumeroConta = numeroConta;
            DigitoConta = digitoConta;
            DataAbertura = dataAbertura;
            SaldoAtual = saldoAtual;
        }

        public void DepositarValorSaldo(decimal valor)
        {
            ValidadorDeRegra.Novo()
                .Quando(valor <= 0, Resource.ValorMenorQueZero)
                .DispararExcecaoSeExistir();

            SaldoAtual += valor;
        }

        public void RetirarValorSaldo(decimal valor)
        {
            ValidadorDeRegra.Novo()
                .Quando(valor <= 0, Resource.ValorMenorQueZero)
                .Quando(valor > SaldoAtual, Resource.SaldoInsuficiente)
                .DispararExcecaoSeExistir();

            SaldoAtual = SaldoAtual - valor;
        }
    }
}
