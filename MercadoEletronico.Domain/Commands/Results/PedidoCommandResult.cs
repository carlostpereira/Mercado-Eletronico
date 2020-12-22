using MercadoEletronico.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MercadoEletronico.Domain.Commands.Results
{
    public class PedidoCommandResult : ICommandResult
    {
        public string CodigoPedido { get; set; }
        public ICollection<ItemPedidoCommandResult> Itens { get; set; }
    }

    public class ItemPedidoCommandResult : ICommandResult
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Qtd { get; set; }
        public string CodigoPedido { get; set; }
    }

    public class PedidoCommandResultList : ICommandResult
    {
        public PedidoCommandResultList()
        {
            Pedidos = new List<PedidoCommandResult>();
        }

        public ICollection<PedidoCommandResult> Pedidos { get; set; }
    }
}
