using MercadoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MercadoEletronico.Infrastructure.Contexts
{
    public class MercadoEletronicoContext: DbContext
    {
        public MercadoEletronicoContext(DbContextOptions<MercadoEletronicoContext> options) : base(options)
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
