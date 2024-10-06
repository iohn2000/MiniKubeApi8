namespace MiniKubeApi8;
public class Program
{
    private static readonly string[] swaggerEnabledEnvironments = new string[] { "uat", "Development","prod" };

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure logging
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

        var env = builder.Environment;

        string appSettingsFileEnv = $"appsettings.{env.EnvironmentName}.json";
        logger.LogInformation($"appSettingsFileEnv: {appSettingsFileEnv}");

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile(appSettingsFileEnv, optional: false, reloadOnChange: true)
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
        Console.WriteLine("app.Run");
    }
}
