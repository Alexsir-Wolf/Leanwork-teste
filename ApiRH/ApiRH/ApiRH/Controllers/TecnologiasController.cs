using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Commands.Input.Tecnologias;
using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.API.Controllers.Base;

namespace ApiRH.API.Controllers
{
    public class TecnologiasController : BaseController
    {
        private readonly ITecnologiaHandler _tecnologiaHandler;

        public TecnologiasController(ITecnologiaHandler tecnologiaHandler)
        {
            _tecnologiaHandler = tecnologiaHandler;
        }

        /// <summary>
        /// Cria uma nova tecnologia.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "Nome": "RH"
        ///     }
        ///
        /// </remarks>
        /// <returns>Uma nova tecnologia foi criada.</returns>
        /// <response code="201">Retorna a nova tecnologia criada.</response>
        /// <response code="400">Se a nova tecnologia não for criada.</response>    
        [HttpPost]
        [Produces("application/json")]
        [SwaggerResponse(201, Type = typeof(CommandResult<TecnologiaCommandResult>))]
        public async Task<CommandResult<TecnologiaCommandResult>> Registrar(TecnologiaCommand command)
        {
            return await _tecnologiaHandler.RegistrarTecnologia(command);
        }

        /// <summary>
        /// Altera uma tecnologia.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "Nome": "RH"
        ///     }
        ///
        /// </remarks>
        /// <returns>Tecnologia alterada.</returns>
        /// <response code="200">Retorna a tecnologia alterada.</response>
        /// <response code="400">Se a tecnologia não for alterada.</response>    
        /// <param name="id">Id da tecnologia a ser alterada.</param>
        /// <param name="model"></param>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<TecnologiaCommandResult>))]
        public async Task<CommandResult<TecnologiaCommandResult>> Editar(int id, [FromBody] TecnologiaCommand model)
        {
            return await _tecnologiaHandler.AlterarTecnologia(id, model);
        }

        /// <summary>
        /// Lista todas as tecnologias.
        /// </summary>
        /// <remarks />
        /// <returns>Lista todas as tecnologias cadastradas e ativas.</returns>
        /// <response code="200">Retorna lista de tecnologias.</response>
        /// <response code="400">Se ocorrer algum erro ao listar as tecnologias.</response>    
        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<List<TecnologiaCommandResult>>))]
        public async Task<CommandResult<List<TecnologiaCommandResult>>> Listar()
        {
            return await _tecnologiaHandler.ListarTecnologias();
        }

        /// <summary>
        /// Obtem uma tecnologia por id.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna a tecnologia consultada.</response>
        /// <response code="400">Se a tecnologia não for consultada.</response>
        /// <param name="id">Id da tecnologia a ser consultada.</param>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<TecnologiaCommandResult>))]
        public async Task<CommandResult<TecnologiaDetalheCommandResult>> ObtemPorId(int id)
        {
            return await _tecnologiaHandler.ObterTecnologiaPorId(id);
        }

        /// <summary>
        /// Exclui uma tecnologia.
        /// </summary>
        /// <returns>Tecnologia excluída.</returns>
        /// <response code="200">tecnologia excluída.</response>
        /// <response code="400">Se a tecnologia não for excluída.</response>
        /// <param name="id">Id da tecnologia a ser excluída.</param>
        [HttpDelete("{id}")]
        [SwaggerResponse(200, Type = typeof(CommandResult<object>))]
        public async Task<CommandResult<object>> Excluir(int id)
        {
            return await _tecnologiaHandler.ExcluirTecnologia(id);
        }
    }
}
