using Microsoft.Extensions.DependencyInjection;
using SD.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SD.Persistence.Extensions
{
    public static class ServiceBuilderExtension
    {
        //so sieht Konstrukt von Extension aus, damit man die Methode RegisterRepositories in der SD.Application verwenden kann,
        //um alle Repositories zu registrieren, die mit dem Attribut MapServiceDependency markiert sind
        public static void RegisterRepositories(this IServiceCollection services) //this braucht es, dass es Extension ist
        {
            services.Scan(scan =>
            {
                scan.FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(c => c.WithAttribute<MapServiceDependencyAttribute>()) //nur Klassen, die mit MapServiceDependencyAttribute markiert sind
                    .AsImplementedInterfaces() //alle Interfaces, die von diesen Klassen implementiert werden, werden automatisch registriert
                    .WithScopedLifetime(); //Lebensdauer der Instanzen, in diesem Fall Scoped, d.h. eine Instanz pro Anfrage
            });
        }
    }
}
