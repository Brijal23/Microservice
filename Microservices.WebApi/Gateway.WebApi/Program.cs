
namespace Gateway.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var builder = WebApplication.CreateBuilder(args);

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config
        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
    });
    }
}