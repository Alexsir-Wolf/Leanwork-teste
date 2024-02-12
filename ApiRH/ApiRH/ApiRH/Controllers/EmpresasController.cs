using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Commands.Input.Empresas;
using ApiRH.Dominio.Commands.Output.Empresas;
using ApiRH.API.Controllers.Base;

namespace ApiRH.API.Controllers
{
    public class EmpresasController : BaseController
    {
        private readonly IEmpresaHandler _empresaHandler;

        public EmpresasController(IEmpresaHandler empresaHandler)
        {
            _empresaHandler = empresaHandler;
        }

        /// <summary>
        /// Cria uma nova empresa.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "Nome": "Empresa",
        ///        "CNPJ": "CNPJ",
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
        /// <returns>Uma nova empresa foi criada.</returns>
        /// <response code="201">Retorna a nova empresa criada.</response>
        /// <response code="400">Se a nova empresa não for criada.</response>    
        [HttpPost]
        [Produces("application/json")]
        [SwaggerResponse(201, Type = typeof(CommandResult<EmpresaCommandResult>))]
        public async Task<CommandResult<EmpresaCommandResult>> Registrar(EmpresaCommand command)
        {
            return await _empresaHandler.RegistrarEmpresa(command);
        }

        /// <summary>
        /// Altera uma empresa.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "Nome": "Empresa",
        ///        "CNPJ": "CNPJ",
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
        /// <returns>Empresa alterada.</returns>
        /// <response code="200">Retorna a empresa alterada.</response>
        /// <response code="400">Se a empresa não for alterada.</response>    
        /// <param name="id">Id da empresa a ser alterada.</param>
        /// <param name="model"></param>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<EmpresaCommandResult>))]
        public async Task<CommandResult<EmpresaCommandResult>> Editar(int id, [FromBody] EmpresaCommand model)
        {
            return await _empresaHandler.AlterarEmpresa(id, model);
        }

        /// <summary>
        /// Lista todas as empresas.
        /// </summary>
        /// <remarks />
        /// <returns>Lista todas as empresas cadastradas e ativas.</returns>
        /// <response code="200">Retorna lista de empresas.</response>
        /// <response code="400">Se ocorrer algum erro ao listar as empresas.</response>    
        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<List<EmpresaCommandResult>>))]
        public async Task<CommandResult<List<EmpresaCommandResult>>> Listar()
        {
            return await _empresaHandler.ListarEmpresas();
        }

        /// <summary>
        /// Obtem uma empresa por id.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna a empresa consultada.</response>
        /// <response code="400">Se a empresa não for consultada.</response>
        /// <param name="id">Id da empresa a ser consultada.</param>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(CommandResult<EmpresaCommandResult>))]
        public async Task<CommandResult<EmpresaDetalheCommandResult>> ObtemPorId(int id)
        {
            return await _empresaHandler.ObterEmpresaPorId(id);
        }

        /// <summary>
        /// Exclui uma empresa.
        /// </summary>
        /// <returns>Empresa excluída.</returns>
        /// <response code="200">empresa excluída.</response>
        /// <response code="400">Se a empresa não for excluída.</response>
        /// <param name="id">Id da empresa a ser excluída.</param>
        [HttpDelete("{id}")]
        [SwaggerResponse(200, Type = typeof(CommandResult<object>))]
        public async Task<CommandResult<object>> Excluir(int id)
        {
            return await _empresaHandler.ExcluirEmpresa(id);
        }
    }
}
