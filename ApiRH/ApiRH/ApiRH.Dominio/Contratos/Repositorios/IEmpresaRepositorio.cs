using ApiRH.Dominio.Core.Data.Repositorios;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Contratos.Repositorios;

public interface IEmpresaRepositorio : IBaseRepositorio<Empresa, int>
{
    Task<Empresa> ObterEmpresaPorId(int id);
    Task<ICollection<Empresa>> ListarEmpresas();
    Task AlterarEmpresa(int id, Empresa empresa);
}
