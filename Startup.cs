using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProductCatalog.Data;
using ProductCatalog.Repositories;
using System;


namespace ProductCatalog
{
    public class Startup
    {

        // Método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona serviços para controladores ao IServiceCollection.
            // Este método não registrará serviços usados para visualizações ou páginas.
            services.AddControllers();

            // Adição do serviço de compressão de response.
            services.AddResponseCompression();

            // Adiciona o DataContext como dependência
            services.AddScoped<StoreDataContext, StoreDataContext>();

            // Adiciona um serviço temporário do tipo especificado em TService
            services.AddTransient<CategoryRepository, CategoryRepository>();
            services.AddTransient<ProductRepository, ProductRepository>();

            // Registrar o gerador Swagger, definindo mais documentos Swagger
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // Método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Verifica qual ambiente o App se encontra
            if (env.IsDevelopment())
            {
                // Middleware para capturar instâncias System.Exception síncronas e assíncronas do pipeline e gera respostas de erro HTML.
                app.UseDeveloperExceptionPage();

                // Middleware para servir o Swagger gerado como um terminal JSON.
                app.UseSwagger();
                // Middleware para servir swagger-ui (HTML, JS, CSS, etc.), especificando o endpoint JSON Swagger
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductCatalog V1"));
            }

            // Middleware de roteamento para rotear as requests (resolução de endpoint)
            app.UseRouting();

            // Middleware de despacho de endpoint (Dispatcher - Executar o endpoint correspondente)
            app.UseEndpoints(endpoints =>
            {
                // Configuração do mapa de rota
                endpoints.MapControllers();

                // Configuração manual
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            // Middleware para compactar dinamicamente as respostas HTTP.
            app.UseResponseCompression();
        }
    }
}
