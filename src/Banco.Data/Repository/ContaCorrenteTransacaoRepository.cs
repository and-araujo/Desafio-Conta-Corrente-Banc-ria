using Banco.Business.Interfaces;
using Banco.Business.Models;
using Banco.Data.Context;

namespace Banco.Data.Repository
{
    public class ContaCorrenteTransacaoRepository : Repository<ContaCorrenteTransacao>, IContaCorrenteTransacaoRepository
    {
        public ContaCorrenteTransacaoRepository(BancoDbContext context) : base(context) { }
    }
}
