using MercadoEletronico.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronico.Domain.Repositories
{
    public interface IPedidosRepository
    {
        Task<Pedido> GetByCodigoPedido(string codigoPedido);
        Task<ICollection<Pedido>> GetAll();
        Task Save(Pedido pedido);
        void Update(Pedido pedido);
    }
}

