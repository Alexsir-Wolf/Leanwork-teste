using ApiRH.Dominio.Commands.Input.Vagas;
using ApiRH.Dominio.Commands.Output.Vagas;
using ApiRH.Dominio.Core.Commands;

namespace ApiRH.Dominio.Contratos.Handlers
{
    public interface IVagaHandler
    {
        Task<CommandResult<VagaCommandResult>> RegistrarVaga(VagaCommand command);
        Task<CommandResult<VagaCommandResult>> AlterarVaga(int id, VagaCommand command);
        Task<CommandResult<List<VagaCommandResult>>> ListarVagas();
        Task<CommandResult<VagaDetalheCommandResult>> ObterVagaPorId(int id);
        Task<CommandResult<object>> ExcluirVaga(int id);
    }
}
