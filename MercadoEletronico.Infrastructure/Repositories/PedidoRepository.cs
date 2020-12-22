using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Domain.Repositories;
using MercadoEletronico.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronico.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidosRepository
    {
        private readonly MercadoEletronicoContext context;

        public PedidoRepository(MercadoEletronicoContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Pedido>> GetAll()
        {
            return await context
                .Pedidos
                .Include("Itens")
                .AsNoTracking()
                .OrderBy(x => x.CodigoPedido)
                .ToListAsync();
        }

        public async Task<Pedido> GetByCodigoPedido(string codigoPedido)
        {
            return await context
                .Pedidos
                .Include("Itens")
                .AsNoTracking()
                .Where(x => x.CodigoPedido == codigoPedido)
                .FirstOrDefaultAsync();
        }

        public async Task Save(Pedido pedido)
        {
            await context.Pedidos.AddAsync(pedido);
        }

        public void Update(Pedido pedido)
        {
            context.Entry(pedido).State = EntityState.Modified;
        }
    }
}
