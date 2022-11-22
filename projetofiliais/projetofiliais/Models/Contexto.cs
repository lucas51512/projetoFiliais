using Microsoft.EntityFrameworkCore;
using projetofiliais.Models;

namespace projetofiliais.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Filial> filiais { get; set; }
        public DbSet<Transacao> transacoes { get; set; }
    }
}
