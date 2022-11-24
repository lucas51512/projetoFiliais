using Microsoft.EntityFrameworkCore;
using criptowebbcc.Models.Consulta;

namespace criptowebbcc.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
     
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Filial> filiais { get; set; }
        public DbSet<Transacao> transacoes { get; set; }
        public DbSet<criptowebbcc.Models.Consulta.TransacaoQry> TransacaoQry { get; set; }
        public DbSet<criptowebbcc.Models.Consulta.TransacaoGrpProduto> TransacaoGrpProduto { get; set; }
        public DbSet<criptowebbcc.Models.Consulta.TransacaoGrpMes> TransacaoGrpMes { get; set; }
    }
}
