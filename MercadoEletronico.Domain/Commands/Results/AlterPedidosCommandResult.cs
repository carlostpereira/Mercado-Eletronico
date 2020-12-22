using MercadoEletronico.Shared.Commands;
using MercadoEletronico.Shared.Enumerators;

namespace MercadoEletronico.Domain.Commands.Results
{
    public class AlterPedidosCommandResult : ICommandResult
    {
        public AlterPedidosCommandResult()
        {
        }

        public AlterPedidosCommandResult(int pedido, StatusPedido status)
        {
            Pedido = pedido;
            Status = status;
        }

        public int Pedido { get; set; }
        public StatusPedido Status { get; set; }
    }
}
