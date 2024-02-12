using ApiRH.Dominio.Commands.Input.Candidatos;
using ApiRH.Dominio.Commands.Output.Candidatos;
using ApiRH.Dominio.Core.Commands;

namespace ApiRH.Dominio.Contratos.Handlers
{
    public interface ICandidatoHandler
    {
        Task<CommandResult<CandidatoCommandResult>> RegistrarCandidato(CandidatoCommand command);
        Task<CommandResult<CandidatoCommandResult>> AlterarCandidato(int id, CandidatoCommand command);
        Task<CommandResult<List<CandidatoCommandResult>>> ListarCandidatos();
        Task<CommandResult<List<CandidatoCommandResult>>> ListarCandidatosPorVaga(int id);
        Task<CommandResult<CandidatoDetalheCommandResult>> ObterCandidatoPorId(int id);
        Task<CommandResult<object>> ExcluirCandidato(int id);
    }
}
