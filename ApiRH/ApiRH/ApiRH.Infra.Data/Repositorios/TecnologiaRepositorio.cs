using ApiRH.Dominio;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Dominio.Entidades;
using ApiRH.Infra.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiRH.Infra.Data.Repositorios;

public class TecnologiaRepositorio : BaseRepositorio<Tecnologia, int>, ITecnologiaRepositorio 
{
    private readonly ApiRHDbContext _dbContext;

    public TecnologiaRepositorio(ApiRHDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}