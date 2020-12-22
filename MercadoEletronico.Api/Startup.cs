using MercadoEletronico.Api.IoC;
using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Domain.Repositories;
using MercadoEletronico.Infrastructure.Contexts;
using MercadoEletronico.Infrastructure.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace MercadoEletronico.Api
{
    public class Startup
    {
        private IPedidosRepository repository;
        private IUow uow;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors();

            services
                .AddControllers()
                .AddNewtonsoftJson(options => {

                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                });

            DependenceResolver.Register(services);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Mercado Eletrônico API",
                    Description = "API de teste para desafio Mercado Eletrônico",
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IPedidosRepository repository, IUow uow)
        {
            this.repository = repository;
            this.uow = uow;

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = string.Empty;
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            GerarPedidoMemoria();
        }

        private void GerarPedidoMemoria()
        {
            var pedido = new Pedido("123456");
            pedido.Itens.Add(new ItemPedido("Item A", 10, 1, pedido.CodigoPedido));
            pedido.Itens.Add(new ItemPedido("Item B", 5, 2, pedido.CodigoPedido));

            repository.Save(pedido);
            uow.Commit();
        }
    }
}
