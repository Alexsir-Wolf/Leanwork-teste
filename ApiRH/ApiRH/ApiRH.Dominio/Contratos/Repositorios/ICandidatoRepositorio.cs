using ApiRH.Dominio.Core.Data.Repositorios;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Contratos.Repositorios;

public interface ICandidatoRepositorio : IBaseRepositorio<Candidato, int>
{
    Task<Candidato> ObterCandidatoPorId(int id);
    Task<ICollection<Candidato>> ListarCandidatos();
    Task<ICollection<Candidato>> ListarCandidatosPorVaga(int id);
    Task AlterarCandidato(int id, Candidato candidato);
}
