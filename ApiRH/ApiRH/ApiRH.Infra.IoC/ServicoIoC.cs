using ApiRH.Dominio;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Infra.Data.Repositorios;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Handlers;

namespace ApiRH.Infra.IoC;

public static class ServicoIoC
{
    public static void ResolveDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApiRHDbContext>(options => options.UseSqlServer(builder
            .Configuration
            .GetSection("Settings")
            .GetSection("SQLServerSettings")
            .GetSection("ConnectionString").Value));

        #region Handlers

        builder.Services.AddScoped<ICandidatoHandler, CandidatoHandler>();
        builder.Services.AddScoped<IEmpresaHandler, EmpresaHandler>();
        builder.Services.AddScoped<ITecnologiaHandler, TecnologiaHandler>();
        builder.Services.AddScoped<IVagaHandler, VagaHandler>();

        #endregion


        #region Repositorios

        builder.Services.AddScoped<ICandidatoRepositorio, CandidatoRepositorio>();
        builder.Services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
        builder.Services.AddScoped<ITecnologiaRepositorio, TecnologiaRepositorio>();
        builder.Services.AddScoped<IVagaRepositorio, VagaRepositorio>();

        #endregion
                

    }
}