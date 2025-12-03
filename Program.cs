using BlackLineCountChecker;
using BlackLineCountChecker.Interfaces;
using BlackLineCountChecker.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    /// <summary>
    /// Application entry point.Configures DI and runs the application .
    /// </summary>
    static void Main(string[] args)
    {
        // Build the DI container
        var host = CreateHostBuilder(args).Build();

        try
        {
            // Resolve and run the application
            var app = host.Services.GetRequiredService<ImageProcessor>();
            app.Run(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Configures the dependency injection container with all application services.
    /// </summary>
    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Register core services
                services.AddSingleton<IImageLoader, ImageSharpLoader>();
                services.AddSingleton<ILineDetector, VerticalBlackLineDetector>();
                services.AddSingleton<IInputValidator, InputValidator>();

                // Register line counting service
                services.AddSingleton<LineCountingService>();
                // Register main application
                services.AddSingleton<ImageProcessor>();
            });
}