using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProductCatalog
{
    public class Startup
    {
        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adicionar o serviço MVC a coleção de serviços
            services.AddMvc();
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Captura instâncias System.Exception síncronas e assíncronas do pipeline e gera respostas de erro HTML.
                app.UseDeveloperExceptionPage();
            }

            // Adiciona MVC ao pipeline de execução do request
            app.UseMvc();
        }
    }
}
