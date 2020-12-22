using Biblioteca.Domain.Commands.Request;
using MercadoEletronico.Domain.Commands.Handlers;
using MercadoEletronico.Domain.Commands.Inputs;
using MercadoEletronico.Infrastructure.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MercadoEletronico.Api.Controllers
{
    public class PedidosController: BaseController
    {
        private readonly PedidosCommandHandler handler;

        public PedidosController(IUow uow, PedidosCommandHandler handler) 
            : base(uow)
        {
            this.handler = handler;
        }

        [HttpGet]
        [Route("v1/Pedido/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = handler.Handle();
            if (data != null)
                return await Response(data);

            return await Response(data, "Nenhum pedido encontrado");
        }

        [HttpGet]
        [Route("v1/Pedido/GetByCodigoPedido/{codigoPedido}")]
        public async Task<IActionResult> GetByCodigoPedido(string codigoPedido)
        {
            var request = new SelectPedidoByCodigoRequestCommand
            {
                Pedido = codigoPedido
            };

            var data = handler.Handle(request);
            if (data != null)
                return await Response(data);

            return await Response(data, $"Pedido {codigoPedido} não encontrado");
        }

        [HttpPost]
        [Route("v1/Pedido/SalvarPedido")]
        public async Task<IActionResult> Post([FromBody] RegisterPedidosCommand command)
        {
            var data = handler.Handle(command);
            if (data != null)
                return await Response(data);

            return await Response(data);
        }

        [HttpPut]
        [Route("v1/Pedido/AlterarStatus")]
        public async Task<IActionResult> Put([FromBody] AlterPedidosCommand command)
        {
            #warning Não implementado por falta de tempo. Devido ao projeto que estou finalizando.

            var data = handler.HandleUpdate(command);
            if (data != null)
                return await Response(data);

            return await Response(data);
        }


    }
}
