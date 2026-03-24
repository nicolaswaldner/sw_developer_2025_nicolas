using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SimpleSteps.Business.Services;
using SimpleSteps.Data;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SimpleSteps.GuiWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/simplesteps-.txt", rollingInterval: RollingInterval.Day)
                .CreateBootstrapLogger();

            Log.Information("App is starting");

            AppHost = Host.CreateDefaultBuilder()
                .UseSerilog((context, services, loggerConfiguration) =>
                {
                    loggerConfiguration
                        .ReadFrom.Configuration(context.Configuration)
                        .ReadFrom.Services(services)
                        .Enrich.FromLogContext();
                })

                //.ConfigureAppConfiguration((context, config) =>
                //{
                //    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                //})
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

                    //services.Configure<AppSettings>(
                    //    context.Configuration.GetSection("AppSettings"));

                    services.AddScoped<AppUserService>();
                    //services.AddTransient<MainWindowViewModel>();
                    //services.AddTransient<MainWindow>();

                })
                .Build();



        }



    }

}
