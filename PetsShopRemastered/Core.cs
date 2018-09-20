using Microsoft.Extensions.DependencyInjection;
using PetsShopApp.Core.ApplicationService.Services;
using PetsShopApp.Core.Entity.Repositories;
using PetsShopApp.Core.ApplicationService.Implementation;
using PetsShopRemastered;
using PetsShopApp.Core.DomainService.IPetsRepository;
using PetShopRemastered.Infrastructure.Static.Data.Repositories;

namespace PetsShopRemastered
{

    class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetsRepository, PetsRepository>();
            serviceCollection.AddScoped<IPetsService, PetsService>();


            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            FakeDb.InitData();
            printer.MakeMenu();
        }
    }
}