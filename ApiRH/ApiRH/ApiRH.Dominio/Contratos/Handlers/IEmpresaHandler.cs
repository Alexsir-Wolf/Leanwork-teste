using ApiRH.Dominio.Commands.Input.Empresas;
using ApiRH.Dominio.Commands.Output.Empresas;
using ApiRH.Dominio.Core.Commands;

namespace ApiRH.Dominio.Contratos.Handlers
{
    public interface IEmpresaHandler
    {
        Task<CommandResult<EmpresaCommandResult>> RegistrarEmpresa(EmpresaCommand command);
        Task<CommandResult<EmpresaCommandResult>> AlterarEmpresa(int id, EmpresaCommand command);
        Task<CommandResult<List<EmpresaCommandResult>>> ListarEmpresas();
        Task<CommandResult<EmpresaDetalheCommandResult>> ObterEmpresaPorId(int id);
        Task<CommandResult<object>> ExcluirEmpresa(int id);
    }
}
