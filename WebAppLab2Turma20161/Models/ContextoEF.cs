using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebAppLab2Turma20161.Models.Configurations;

namespace WebAppLab2Turma20161.Models
{
    public class ContextoEF : DbContext
    {
        public ContextoEF():base("name=DefaultConnection")
        {

        }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItensDoPedido> ProdutosEncomendados { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ConfiguracaoCliente());
            //modelBuilder.Configurations.Add(new ConfiguracaoPedido());
            //modelBuilder.Configurations.Add(new ConfiguracaoCategoria());
            //modelBuilder.Configurations.Add(new ConfiguracaoProduto());
        }
    }
}