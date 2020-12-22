using MercadoEletronico.Shared.Commands;
using MercadoEletronico.Shared.Enumerators;

namespace MercadoEletronico.Domain.Commands.Inputs
{
    public class AlterPedidosCommand : ICommand
    {
        public int Pedido { get; set; }
        public StatusPedido Status { get; set; }
        public decimal ValorAprovado { get; set; }
        public int ItensAprovado { get; set; }
    }

}

