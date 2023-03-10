using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace supermercadoMVC.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Produto> Produtos { get; set; }
        public DbSet<Models.ItemCarrinho> ItensCarrinho { get; set; }
        public DbSet<Models.Pedido> Pedidos { get; set; }
        public DbSet<Models.ItemPedido> ItensPedido { get; set; }
    }
}