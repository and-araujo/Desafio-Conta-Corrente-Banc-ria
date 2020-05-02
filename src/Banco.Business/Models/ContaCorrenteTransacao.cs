
using System;

namespace Banco.Business.Models
{
    public class ContaCorrenteTransacao : Entity
    {
        public int  ContaCorrenteId { get; set; }
        public DateTime DataTransacao { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public decimal ValorTransacao { get; set; }

        /* EF Relations */
        public ContaCorrente ContaCorrente { get; set; }
    }
}
