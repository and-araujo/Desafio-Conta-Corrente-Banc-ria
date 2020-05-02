using Banco.Business.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Banco.App.ViewModels
{
    public class ContaCorrenteTransacaoViewModel
    {
        [Key]
        public int Id { get; set; }
        public int ContaCorrenteId { get; set; }
        public DateTime DataTransacao { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public decimal ValorTransacao { get; set; }
        public ContaCorrenteViewModel ContaCorrenteViewModel { get; set; }
    }
}
