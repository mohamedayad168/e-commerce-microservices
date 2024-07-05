using Marten;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            builder.Services.AddMarten(options =>
            {
                options.Connection(builder.Configuration.GetConnectionString("Database")!);
            });
            builder.Services.AddCarter();
            var app = builder.Build();

            app.MapCarter();

            app.Run();
        }
    }
}