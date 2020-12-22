using MercadoEletronico.Domain.Commands.Results;
using MercadoEletronico.Shared.Commands;
using System.Collections.Generic;

namespace MercadoEletronico.Domain.Commands.Inputs
{
    public class RegisterPedidosCommand : ICommand
    {
        public RegisterPedidosCommand()
        {
            Itens = new List<ItemPedidoCommandResult>();
        }

        public string CodigoPedido { get; set; }
        public ICollection<ItemPedidoCommandResult> Itens { get; set; }
    }

}
