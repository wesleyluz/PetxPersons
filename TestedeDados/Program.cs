using Microsoft.Extensions.DependencyInjection;
using TestedeDados.Business;
using TestedeDados.Business.Implemenatations;
using TestedeDados.Model.Context;
using TestedeDados.ProgramControllers;
using TestedeDados.Repository.Generic;


namespace TestedeDados
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Providencia os serviços para injeção de dependência
            var servicesCollection = new ServiceCollection();
            ConfigureServices(servicesCollection);
            var serviceProvider = servicesCollection.BuildServiceProvider();
            // Injeta Controller para as operações basicas
            var eventService = serviceProvider.GetService<IController>();
            //eventService.Delete();
            eventService.PopularPessoas();
            eventService.PopularPets();
            eventService.Start();

        }

        //Serviço de injeção 
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SQLContext>();

            services.AddScoped<IPessoasBusiness, PessoasBusiness>()
            .AddScoped<IPetsBusiness, PetsBusiness>()
            .AddScoped<IController, Controller>()
            .AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));

            
            
        }
    }
}
