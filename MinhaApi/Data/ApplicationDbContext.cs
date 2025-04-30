using Microsoft.EntityFrameworkCore;
using GerenciamentoEstoque.Models;

namespace GerenciamentoEstoque.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Armazem> Armazens { get; set; }
        public DbSet<ProdutoXArmazem> ProdutoXArmazens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProdutoXArmazem>()
                .HasOne(pxa => pxa.Produto)
                .WithMany(p => p.ProdutosXArmazens)
                .HasForeignKey(pxa => pxa.IdProduto);

            modelBuilder.Entity<ProdutoXArmazem>()
                .HasOne(pxa => pxa.Armazem)
                .WithMany(a => a.ProdutosXArmazens)
                .HasForeignKey(pxa => pxa.IdArmazem);
        }

    }
}