using Banco.Business.Interfaces;
using Banco.Business.Models;
using Banco.Data.Context;

namespace Banco.Data.Repository
{
    public class ContaCorrenteRepository : Repository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(BancoDbContext context) : base(context) { }        
    }
}
