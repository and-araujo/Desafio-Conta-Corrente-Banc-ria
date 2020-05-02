using Banco.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Data.Context
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
        public DbSet<ContaCorrenteTransacao> ContaCorrenteTransacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
