using ApiRH.Dominio;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Dominio.Entidades;
using ApiRH.Infra.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiRH.Infra.Data.Repositorios;

public class EmpresaRepositorio : BaseRepositorio<Empresa, int>, IEmpresaRepositorio 
{
    private readonly ApiRHDbContext _dbContext;

    public EmpresaRepositorio(ApiRHDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Empresa> ObterEmpresaPorId(int id)
    {
        try
        {
            var empresa = await _dbContext.Empresa
                .AsNoTracking()
                .Include(t => t.EmpresaTecnologias)
                    .ThenInclude(x => x.Tecnologia)
                    .Distinct()
                .Where(x => x.Id == id && x.Ativo)
                .FirstOrDefaultAsync();

            return empresa;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }    
    
    public async Task<ICollection<Empresa>> ListarEmpresas()
    {
        try
        {
            var empresa = await _dbContext.Empresa
                .AsNoTracking()
                .Include(t => t.EmpresaTecnologias)
                    .ThenInclude(x => x.Tecnologia)
                .ToListAsync();

            return empresa;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task AlterarEmpresa(int id, Empresa empresa)
    {
        try
        {
            await DeletarEmpresaTecnologia(empresa.Id);
            await base.UpdateAsync(id, empresa);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task DeletarEmpresaTecnologia(int id)
    {
        try
        {
            var empresaTecnologia = _dbContext.EmpresaTecnologia.Where(x => x.EmpresaId == id);
            _dbContext.EmpresaTecnologia.RemoveRange(empresaTecnologia);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}