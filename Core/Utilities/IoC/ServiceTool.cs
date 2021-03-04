using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //We api veya autofacta oluşturuğumuz injeksinları,oluşturabilmemizi sağlar
    //istenen interface'in servisteki karşılığını bu tool ile alabiliriz.
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        //.NET'in servislerini kullan ve onları kendin build et
        public static IServiceCollection Create(IServiceCollection services)
        {
          
          
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
