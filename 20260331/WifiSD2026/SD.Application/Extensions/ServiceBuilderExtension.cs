using Microsoft.Extensions.DependencyInjection;
using SD.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SD.Application.Extensions
{
    public static class ServiceBuilderExtension
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromAssemblies(Assembly.GetExecutingAssembly()) //alle Klassen aus dem aktuellen Assembly
                    .AddClasses(c => c.WithAttribute<MapServiceDependencyAttribute>()) //nur Klassen, die mit MapServiceDependencyAttribute markiert sind
                    .AsSelf() //die Klasse selbst wird als Service
                    .WithScopedLifetime(); //Lebensdauer der Instanzen, in diesem Fall Scoped, d.h. eine Instanz pro Anfrage
            });
        }
    }
}
