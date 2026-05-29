using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SimpleSteps.Business;
using SimpleSteps.Business.Services;
using SimpleSteps.Data;
using SimpleSteps.GuiWpf.ViewModels;
using SimpleSteps.GuiWpf.Views;
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
                    services.AddScoped<LocationService>();
                    services.AddScoped<RoomService>();
                    services.AddScoped<MeasuredDataService>();

                    //Repository zum DIJ-Container hinzufügen
                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



                    //services.AddTransient<MainWindow>();

                    services.AddTransient<vmSimpleSteps>();
                    services.AddTransient<vSimpleSteps>();

                    //services.AddTransient<MainWindowViewModel>();



                })
                .Build();

            Log.Information("Services initialized");

            var mainWindow = AppHost.Services.GetRequiredService<vSimpleSteps>();
            mainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            mainWindow.Show();


        }



    }

}
