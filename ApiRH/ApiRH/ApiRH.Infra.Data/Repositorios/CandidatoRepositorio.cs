using ApiRH.Dominio;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Dominio.Entidades;
using ApiRH.Infra.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiRH.Infra.Data.Repositorios;

public class CandidatoRepositorio : BaseRepositorio<Candidato, int>, ICandidatoRepositorio 
{
    private readonly ApiRHDbContext _dbContext;

    public CandidatoRepositorio(ApiRHDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Candidato> ObterCandidatoPorId(int id)
    {
        try
        {
            var candidato = await _dbContext.Candidato
                .AsNoTracking()
                .Include(t => t.CandidatoTecnologias)
                    .ThenInclude(x => x.Tecnologia)
                    .Distinct()
                .Where(x => x.Id == id && x.Ativo)
                .FirstOrDefaultAsync();

            return candidato;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<ICollection<Candidato>> ListarCandidatos()
    {
        try
        {
            var candidatos = await _dbContext.Candidato
                .AsNoTracking()
                .Include(t => t.CandidatoTecnologias)
                    .ThenInclude(x => x.Tecnologia)
                .ToListAsync();

            return candidatos;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }  
    
    public async Task<ICollection<Candidato>> ListarCandidatosPorVaga(int id)
    {
        try
        {
            var candidatos = await _dbContext.Candidato
                .AsNoTracking()
                .Include(ct => ct.CandidatoTecnologias)
                    .ThenInclude(t => t.Tecnologia)
                .Include(vc => vc.VagaCandidatos)
                    .ThenInclude(t => t.Vaga)
                .Where(vc => vc.VagaCandidatos.FirstOrDefault().VagaId == id) // Filtra os registros de VagaCandidatos pela ID da vaga
                .ToListAsync();

            return candidatos;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task AlterarCandidato(int id, Candidato candidato)
    {
        try
        {
            await DeletarCandidatoTecnologia(candidato.Id);
            await base.UpdateAsync(id, candidato);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task DeletarCandidatoTecnologia(int id)
    {
        try
        {
            var candidatoTecnologia = _dbContext.CandidatoTecnologia.Where(x => x.CandidatoId == id);
            _dbContext.CandidatoTecnologia.RemoveRange(candidatoTecnologia);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}