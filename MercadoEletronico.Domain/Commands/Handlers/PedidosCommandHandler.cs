using Biblioteca.Domain.Commands.Request;
using MercadoEletronico.Domain.Commands.Inputs;
using MercadoEletronico.Domain.Commands.Results;
using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Domain.Repositories;
using MercadoEletronico.Shared.Commands;
using System.Collections.Generic;

namespace MercadoEletronico.Domain.Commands.Handlers
{
    public class PedidosCommandHandler : ICommandHandler<RegisterPedidosCommand>
    {
        private readonly IPedidosRepository repository;

        public PedidosCommandHandler(IPedidosRepository repository)
        {
            this.repository = repository;
        }

        public ICommandResult Handle()
        {
            var commandObject = repository.GetAll().Result;

            var pedidoResult = new PedidoCommandResultList();
            var itemPedidoResult = new List<ItemPedidoCommandResult>(); 

            foreach (var item in commandObject)
            {
                foreach (var itemPedido in item.Itens)
                {
                    itemPedidoResult.Add(new ItemPedidoCommandResult
                    {
                        CodigoPedido = itemPedido.CodigoPedido,
                        Descricao = itemPedido.Descricao,
                        PrecoUnitario = itemPedido.PrecoUnitario,
                        Qtd = itemPedido.Qtd
                    });
                }

                pedidoResult.Pedidos.Add(new PedidoCommandResult
                {
                    CodigoPedido = item.CodigoPedido,
                    Itens = itemPedidoResult
                });
               
            }

            return pedidoResult;

        }

        public ICommandResult Handle(SelectPedidoByCodigoRequestCommand command)
        {
            var commandObject = repository.GetByCodigoPedido(command.Pedido).Result;

            if (commandObject == null)
            {
                return null;
            }

            var itensPedido = new List<ItemPedidoCommandResult>();
            foreach (var item in commandObject.Itens)
            {
                itensPedido.Add(new ItemPedidoCommandResult
                {
                    CodigoPedido = item.CodigoPedido,
                    Descricao = item.Descricao,
                    PrecoUnitario = item.PrecoUnitario,
                    Qtd = item.Qtd
                });
            }

            return new PedidoCommandResult()
            { 
                CodigoPedido = commandObject.CodigoPedido,
                Itens = itensPedido
            };

        }

        public ICommandResult Handle(RegisterPedidosCommand command)
        {
            var commandObject = new Pedido(command.CodigoPedido);
            foreach (var item in command.Itens)
            {
                commandObject.Itens.Add(new ItemPedido(item.Descricao, item.PrecoUnitario, item.Qtd, item.CodigoPedido));
            }

            repository.Save(commandObject);

            var itensPedido = new List<ItemPedidoCommandResult>();
            foreach (var item in commandObject.Itens)
            {
                itensPedido.Add(new ItemPedidoCommandResult()
                {
                    CodigoPedido = item.CodigoPedido,
                    Descricao = item.Descricao,
                    PrecoUnitario = item.PrecoUnitario,
                    Qtd = item.Qtd
                });
            }

            return new PedidoCommandResult()
            { 
                CodigoPedido = commandObject.CodigoPedido,
                Itens = itensPedido
            };
        }

        public ICommandResult HandleUpdate(AlterPedidosCommand command)
        {
            return new AlterPedidosCommandResult(command.Pedido, command.Status);
        }

    }
}
