using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Commands.Input.Candidatos;
using ApiRH.Dominio.Commands.Output.Candidatos;
using ApiRH.API.Controllers.Base;

namespace ApiRH.API.Controllers
{
    public class CandidatosController : BaseController
    {
        private readonly ICandidatoHandler _candidatoHandler;

        public CandidatosController(ICandidatoHandler candidatoHandler)
        {
            _candidatoHandler = candidatoHandler;
        }

        /// <summary>
        /// Cria um novo candidato.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "Nome": "Candidato",
        ///        "funcao": "Candidato",
        ///        "Tecnologias":[
        ///             {
        ///                 "TecnologiaId": 1
        ///             },        
        ///             {
        ///                 "TecnologiaId": 2
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo candidato foi criado.</returns>
        /// <response code="201">Retorna novo candidato criado.</response>
        /// <response code="400">Se novo candidato não for criado.</response>    
        [HttpPost]
        [Produces("application/json")]
        [SwaggerResponse(201, Type = typeof(CommandResult<CandidatoCommandResult>))]
        public async Task<CommandResult<CandidatoCommandResult>> Registrar(CandidatoCommand command)
        {
            return await _candidatoHandler.RegistrarCandidato(command);
        }

        /// <summary>
        /// Altera um candidato.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "Nome": "Candidato",
        ///        "funcao": "Candidato",
        ///        "Tecnologias":[
        ///             {
        ///                 "TecnologiaId": 1
        ///             },        
        ///             {
        ///                 "TecnologiaId": 2
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Candidato alterado.</returns>
        /// <response code="200">Retorna candidato alterado.</response>
        /// <response code="400">Se candidato não for alterado.</response>    
        /// <param name="id">Id do candidato a ser alterado.</param>
        /// <param name="model"></param>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<CandidatoCommandResult>))]
        public async Task<CommandResult<CandidatoCommandResult>> Editar(int id, [FromBody] CandidatoCommand model)
        {
            return await _candidatoHandler.AlterarCandidato(id, model);
        }

        /// <summary>
        /// Lista todos os candidatos.
        /// </summary>
        /// <remarks />
        /// <returns>Lista todos os candidatos cadastrados e ativos.</returns>
        /// <response code="200">Retorna lista de candidatos.</response>
        /// <response code="400">Se ocorrer algum erro ao listar os candidatos.</response>    
        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<List<CandidatoCommandResult>>))]
        public async Task<CommandResult<List<CandidatoCommandResult>>> Listar()
        {
            return await _candidatoHandler.ListarCandidatos();
        }

        /// <summary>
        /// Lista todos os candidatos por vaga.
        /// </summary>
        /// <remarks />
        /// <returns>Lista todos os candidatos por vaga cadastrados e ativos.</returns>
        /// <response code="200">Retorna lista de candidatos por vaga.</response>
        /// <response code="400">Se ocorrer algum erro ao listar os candidatos.</response>    
        /// <param name="id">Id da vaga a ser consultada.</param>
        [HttpGet("por-vaga/{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<List<CandidatoCommandResult>>))]
        public async Task<CommandResult<List<CandidatoCommandResult>>> ListarPorVaga(int id)
        {
            return await _candidatoHandler.ListarCandidatosPorVaga(id);
        }

        /// <summary>
        /// Obtem um candidato por id.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna o candidato consultado.</response>
        /// <response code="400">Se candidato não for consultado.</response>
        /// <param name="id">Id do candidato a ser consultado.</param>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<CandidatoCommandResult>))]
        public async Task<CommandResult<CandidatoDetalheCommandResult>> ObtemPorId(int id)
        {
            return await _candidatoHandler.ObterCandidatoPorId(id);
        }

        /// <summary>
        /// Exclui um candidato.
        /// </summary>
        /// <returns>Candidato excluído.</returns>
        /// <response code="200">Candidato excluído.</response>
        /// <response code="400">Se candidato não for excluído.</response>
        /// <param name="id">Id do candidato a ser excluído.</param>
        [HttpDelete("{id}")]
        [SwaggerResponse(200, Type = typeof(CommandResult<object>))]
        public async Task<CommandResult<object>> Excluir(int id)
        {
            return await _candidatoHandler.ExcluirCandidato(id);
        }
    }
}
