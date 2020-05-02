using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Business.Models
{
    public interface IConta
    {
        void Depositar(decimal valor);
        void Retirar(decimal valor);
    }

    public abstract class Conta : IConta
    {
        public decimal SaldoAtual { get; set; }
        public void Depositar(decimal valor)
        {
            throw new NotImplementedException();
        }

        public void Retirar(decimal valor)
        {
            throw new NotImplementedException();
        }
    }
}
