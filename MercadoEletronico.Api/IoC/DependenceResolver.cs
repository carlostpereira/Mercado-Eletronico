using MercadoEletronico.Domain.Commands.Handlers;
using MercadoEletronico.Domain.Repositories;
using MercadoEletronico.Infrastructure.Contexts;
using MercadoEletronico.Infrastructure.Repositories;
using MercadoEletronico.Infrastructure.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronico.Api.IoC
{
    public static class DependenceResolver
    {
        public static void Register(IServiceCollection services)
        {

            services.AddDbContext<MercadoEletronicoContext>(opt => opt.UseInMemoryDatabase("MercadoEletronico"));

            services.AddScoped<MercadoEletronicoContext, MercadoEletronicoContext>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<IPedidosRepository, PedidoRepository>();
            services.AddTransient<PedidosCommandHandler, PedidosCommandHandler>();



        }
    }
}
