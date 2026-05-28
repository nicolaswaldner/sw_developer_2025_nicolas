
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using SD.Application.Authentication;
using SD.Application.Extensions;
using SD.Common.Services;
using SD.Persistence.Extensions;
using SD.Persistence.Repositories.DBContext;

namespace SD.WS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(g =>
            {
                g.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Wifi SW-Developer 2025-2026 API",
                    Version = "v1",
                    Contact = new OpenApiContact { Email = "nicolas@example.com", 
                                                    Url = new Uri("https://example.com"), Name = "Nicolas"}
                });

                g.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header, // In definiert, an welchem Bereich vom Swagger die Schaltfläche für LogIn ist
                    Description = "Basic Authentication header using basic scheme"
                });

                g.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecuritySchemeReference("basic", document, null),
                        new List<string>()
                    }
                });
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            //DB Context Registrierung, Verbindung zur Datenbank
            var connectionString = builder.Configuration.GetConnectionString("MovieDbContext");
            builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(connectionString));

            //Registrierung von UserService zur ServiceCollection
            builder.Services.AddScoped<IUserService, UserService>();

            //BasicAuthentication Handler registrieren
            builder.Services.AddAuthentication(nameof(BasicAuthenticationHandler))
                            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(nameof(BasicAuthenticationHandler), null);

            builder.Services.AddAuthorization();

            //zuerst untere Schicht
            builder.Services.RegisterRepositories();
            builder.Services.RegisterApplicationServices();
            builder.Services.AddMediator(cfg => cfg.ServiceLifetime = ServiceLifetime.Scoped);



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //Swagger
                app.UseSwagger();
                app.UseSwaggerUI();

                //Microsoft Scalar
                app.MapOpenApi();

                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            //Uses für Authentication und Authorization aufrufen (diese Reihenfolge wichtig)
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
