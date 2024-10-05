namespace MiniKubeApi8;
public class Program
{
    private static readonly string[] swaggerEnabledEnvironments = new string[] { "Uat", "Development" };

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        var env = builder.Environment;

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.local.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (swaggerEnabledEnvironments.Contains(app.Environment.EnvironmentName))
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
        Console.WriteLine("");
    }
}
