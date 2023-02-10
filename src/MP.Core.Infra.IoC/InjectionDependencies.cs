using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.Core.Application.Mappings;
using MP.Core.Application.Services;
using MP.Core.Application.Services.Interfaces;
using MP.Core.Domain.Repositories;
using MP.Core.Infra.Data.Context;
using MP.Core.Infra.Data.Repositories;

namespace MP.Core.Infra.IoC
{
    public static class InjectionDependencies
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MpDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(DomainToDtoMapping));

            services.AddScoped<IPessoaService, PessoaService>();
            
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            return services;
        }
    }
}
