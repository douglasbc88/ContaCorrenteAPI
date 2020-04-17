using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaCorrente.Business;
using ContaCorrente.Entity;
using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContaCorrente.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Dictionary<int, double> dictContas = new Dictionary<int, double>();

            dictContas.Add(54321, 800.00);
            dictContas.Add(12345, 600.00);
            dictContas.Add(11111, 700.00);

            foreach (KeyValuePair<int, double> kvp in dictContas)
            {
                Conta conta = new Conta()
                {
                    NumeroConta = kvp.Key,
                    Saldo = kvp.Value
                };

                ContaBusiness business = new ContaBusiness();
                business.CadastrarConta(conta);
            }
        }
    }
}
