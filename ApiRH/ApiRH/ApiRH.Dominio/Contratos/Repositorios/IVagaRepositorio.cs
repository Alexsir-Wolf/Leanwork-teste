using ApiRH.Dominio.Core.Data.Repositorios;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Contratos.Repositorios;

public interface IVagaRepositorio : IBaseRepositorio<Vaga, int>
{
    Task<Vaga> ObterVagaPorId(int id);
    Task<ICollection<Vaga>> ListarVagas();
    Task AlterarVaga(int id, Vaga vaga);
}
