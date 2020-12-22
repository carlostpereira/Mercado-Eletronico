using MercadoEletronico.Shared.Commands;

namespace Biblioteca.Domain.Commands.Request
{
    public class SelectPedidoByCodigoRequestCommand : ICommand
    {
        public string Pedido { get; set; }
    }
}
