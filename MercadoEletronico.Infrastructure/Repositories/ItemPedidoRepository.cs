using MercadoEletronico.Domain.Repositories;
using MercadoEletronico.Infrastructure.Contexts;

namespace MercadoEletronico.Infrastructure.Repositories
{
    public class ItemPedidoRepository : IItensPedidoRepository
    {
        private readonly MercadoEletronicoContext _context;

        public ItemPedidoRepository(MercadoEletronicoContext context)
        {
            _context = context;
        }
    }
}
