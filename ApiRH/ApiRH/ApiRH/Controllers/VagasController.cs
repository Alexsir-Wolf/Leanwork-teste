using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Commands.Input.Vagas;
using ApiRH.Dominio.Commands.Output.Vagas;
using ApiRH.API.Controllers.Base;

namespace ApiRH.API.Controllers
{
    public class VagasController : BaseController
    {
        private readonly IVagaHandler _vagaHandler;

        public VagasController(IVagaHandler vagaHandler)
        {
            _vagaHandler = vagaHandler;
        }

        /// <summary>
        /// Cria uma nova vaga.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "descricao": "Vaga",
        ///        "Tecnologias":[
        ///             {
        ///                 "TecnologiaId": 1,
        ///                 "Peso":10
        ///             },        
        ///             {
        ///                 "TecnologiaId": 2,
        ///                 "Peso":10
        ///             }
        ///         ],
        ///         "Candidatos":[
        ///             {
        ///                 "CandidatoId": 1
        ///             },        
        ///             {
        ///                 "CandidatoId": 2
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Uma nova vaga foi criada.</returns>
        /// <response code="201">Retorna a nova vaga criada.</response>
        /// <response code="400">Se a nova vaga não for criada.</response>    
        [HttpPost]
        [Produces("application/json")]
        [SwaggerResponse(201, Type = typeof(CommandResult<VagaCommandResult>))]
        public async Task<CommandResult<VagaCommandResult>> Registrar(VagaCommand command)
        {
            return await _vagaHandler.RegistrarVaga(command);
        }

        /// <summary>
        /// Altera uma vaga.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "descricao": "Vaga",
        ///        "Tecnologias":[
        ///             {
        ///                 "TecnologiaId": 1
        ///             },        
        ///             {
        ///                 "TecnologiaId": 2
        ///             }
        ///         ],
        ///         "Candidatos":[
        ///             {
        ///                 "CandidatoId": 1
        ///             },        
        ///             {
        ///                 "CandidatoId": 2
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Vaga alterada.</returns>
        /// <response code="200">Retorna a vaga alterada.</response>
        /// <response code="400">Se a vaga não for alterada.</response>    
        /// <param name="id">Id da vaga a ser alterada.</param>
        /// <param name="model"></param>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<VagaCommandResult>))]
        public async Task<CommandResult<VagaCommandResult>> Editar(int id, [FromBody] VagaCommand model)
        {
            return await _vagaHandler.AlterarVaga(id, model);
        }

        /// <summary>
        /// Lista todas as vagas.
        /// </summary>
        /// <remarks />
        /// <returns>Lista todas as vagas cadastradas e ativas.</returns>
        /// <response code="200">Retorna lista de vagas.</response>
        /// <response code="400">Se ocorrer algum erro ao listar as vagas.</response>    
        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<List<VagaCommandResult>>))]
        public async Task<CommandResult<List<VagaCommandResult>>> Listar()
        {
            return await _vagaHandler.ListarVagas();
        }

        /// <summary>
        /// Obtem uma vaga por id.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna a vaga consultada.</response>
        /// <response code="400">Se a vaga não for consultada.</response>
        /// <param name="id">Id da vaga a ser consultada.</param>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<VagaCommandResult>))]
        public async Task<CommandResult<VagaDetalheCommandResult>> ObtemPorId(int id)
        {
            return await _vagaHandler.ObterVagaPorId(id);
        }

        /// <summary>
        /// Exclui uma vaga.
        /// </summary>
        /// <returns>Vaga excluída.</returns>
        /// <response code="200">vaga excluída.</response>
        /// <response code="400">Se a vaga não for excluída.</response>
        /// <param name="id">Id da vaga a ser excluída.</param>
        [HttpDelete("{id}")]
        [SwaggerResponse(200, Type = typeof(CommandResult<object>))]
        public async Task<CommandResult<object>> Excluir(int id)
        {
            return await _vagaHandler.ExcluirVaga(id);
        }
    }
}