using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        // injection yakalayabilmemeiz sağlar (mindovs form dada kullanmamızı şagladığımız yer
        // injection alt yaoısını aynne okummamız ısağlar
        //api de yada autofacdeki injection  leri oluşturabilmemizi sağlıyor

        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
