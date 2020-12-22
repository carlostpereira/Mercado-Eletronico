using MercadoEletronico.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MercadoEletronico.Domain.Entities
{
    public class Pedido : Entity
    {
        public Pedido()
        {
            
        }

        public Pedido(string codigoPedido)
        {
            Itens = new List<ItemPedido>();
            this.CodigoPedido = codigoPedido;
        }

        public string CodigoPedido { get; private set; }
        public ICollection<ItemPedido> Itens { get; private set; }
    }
}
