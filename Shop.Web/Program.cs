using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shop.Web;
using Shop.Web.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        RunSeeding(host);
        host.Run();
    }

    /// <summary>
    /// ALIMENTO A LA BASE DE DATOS  CON LA CLASE SEEDDb
    /// </summary>
    /// <param name="host"></param>
    private static void RunSeeding(IWebHost host)
    {
        var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var seeder = scope.ServiceProvider.GetService<SeedDb>();
            seeder.SeedAsync().Wait();
        }
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
}

