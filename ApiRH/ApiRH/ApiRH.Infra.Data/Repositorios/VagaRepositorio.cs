using ApiRH.Dominio;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Dominio.Entidades;
using ApiRH.Infra.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiRH.Infra.Data.Repositorios;

public class VagaRepositorio : BaseRepositorio<Vaga, int>, IVagaRepositorio 
{
    private readonly ApiRHDbContext _dbContext;

    public VagaRepositorio(ApiRHDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Vaga> ObterVagaPorId(int id)
    {
        try
        {
            var vaga = await _dbContext.Vaga
                .AsNoTracking()
                .Include(vt => vt.VagaTecnologias)
                    .ThenInclude(t => t.Tecnologia)
                    .Distinct()
                .Include(vc => vc.VagaCandidatos)
                    .ThenInclude(c => c.Candidato)
                    .Distinct()
                .Where(x => x.Id == id && x.Ativo)
                .FirstOrDefaultAsync();

            return vaga;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<ICollection<Vaga>> ListarVagas()
    {
        try
        {
            var vagas = await _dbContext.Vaga
                .AsNoTracking()
                .Include(t => t.VagaTecnologias)
                    .ThenInclude(x => x.Tecnologia)
                .Include(vc => vc.VagaCandidatos)
                    .ThenInclude(c => c.Candidato)
                    .ThenInclude(ct => ct.CandidatoTecnologias)
                    .ThenInclude(tc => tc.Tecnologia)
                .ToListAsync();

            return vagas;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task AlterarVaga(int id, Vaga vaga)
    {
        try
        {
            await DeletarVagaTecnologia(vaga.Id);
            await base.UpdateAsync(id, vaga);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task DeletarVagaTecnologia(int id)
    {
        try
        {
            var vagaTecnologia = _dbContext.VagaTecnologia.Where(x => x.VagaId == id);
            var vagaCandidato = _dbContext.VagaCandidato.Where(x => x.VagaId == id);

            _dbContext.VagaTecnologia.RemoveRange(vagaTecnologia);
            _dbContext.VagaCandidato.RemoveRange(vagaCandidato);

            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}