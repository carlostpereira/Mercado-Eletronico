using MercadoEletronico.Shared.Entities;
using System;

namespace MercadoEletronico.Domain.Entities
{
    public class ItemPedido: Entity
    {
        public ItemPedido()
        {
        }

        public ItemPedido(string descricao, decimal precoUnitario, int qtd, string codigoPedido)
        {
            this.Descricao = descricao;
            this.PrecoUnitario = precoUnitario;
            this.Qtd = qtd;
            this.CodigoPedido = codigoPedido;
        }

        public string Descricao { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int Qtd { get; private set; }
        public string CodigoPedido { get; private set; }
        public virtual int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

    }
}
