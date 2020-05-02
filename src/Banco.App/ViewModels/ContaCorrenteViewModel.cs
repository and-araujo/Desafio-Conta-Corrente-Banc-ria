using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banco.App.ViewModels
{
    public class ContaCorrenteViewModel
    {
        [Key]
        public int Id { get; set; }
        public int Agencia { get; set; }
        public int NumeroConta { get; set; }
        public int DigitoConta { get; set; }
        public DateTime DataAbertura { get; set; }        
        public decimal SaldoAtual { get; set; }
        public decimal Valor { get; set; }
        public IEnumerable<ContaCorrenteTransacaoViewModel> Transacoes { get; set; }
    }
}
