using ApiRH.Dominio.Commands.Input.Empresas;
using ApiRH.Dominio.Commands.Output.Empresas;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Entidades;
using System.Net;

namespace ApiRH.Dominio.Handlers;

public class EmpresaHandler : IEmpresaHandler
{
    private readonly IEmpresaRepositorio _empresaRepositorio;
    public EmpresaHandler(IEmpresaRepositorio empresaRepositorio)
    {
        _empresaRepositorio = empresaRepositorio;
    }

    public async Task<CommandResult<EmpresaCommandResult>> RegistrarEmpresa(EmpresaCommand command) 
    {
        try
        {
            var result = new CommandResult<EmpresaCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());

            if (!command.IsValid()) 
            {
                result.AddNotificacoes(command);
                return result;
            }

            var empresa = new Empresa().MontarEmpresa(command);
            await _empresaRepositorio.InserirAsync(empresa);

            return new CommandResult<EmpresaCommandResult>(HttpStatusCode.Created.GetHashCode())
            {
                Data = new EmpresaCommandResult().MontarEmpresa(empresa),
                Mensagem = "Empresa criada com sucesso!"
            };          
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<List<EmpresaCommandResult>>> ListarEmpresas()
    {
        try
        {
            var empresas = await _empresaRepositorio.ListarEmpresas();

            return new CommandResult<List<EmpresaCommandResult>>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new EmpresaCommandResult().MontarLista(empresas),
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<EmpresaCommandResult>> AlterarEmpresa(int id, EmpresaCommand command)
    {
        try
        {
            var result = new CommandResult<EmpresaCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());
            if (!command.IsValid())
            {
                result.AddNotificacoes(command);
                return result;
            }

            var empresa = await _empresaRepositorio.ObterIdAsync(Convert.ToInt32(id));
            empresa.MontaAlteracao(command);

            await _empresaRepositorio.AlterarEmpresa(id, empresa);

            return new CommandResult<EmpresaCommandResult>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new EmpresaCommandResult().MontarEmpresa(empresa),
                Mensagem = "Empresa alterada com sucesso!"
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<EmpresaDetalheCommandResult>> ObterEmpresaPorId(int id)
    {
        try
        {
            var empresa = await _empresaRepositorio.ObterEmpresaPorId(id);

            if (empresa != null)
            {
                return new CommandResult<EmpresaDetalheCommandResult>(HttpStatusCode.OK.GetHashCode())
                {
                    Data = new EmpresaDetalheCommandResult().MontarEmpresa(empresa),
                };
            }

            return new CommandResult<EmpresaDetalheCommandResult>(HttpStatusCode.NotFound.GetHashCode())
            {
                Data = new EmpresaDetalheCommandResult(),
                Mensagem = "Empresa não encontrada!"
            };            
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<object>> ExcluirEmpresa(int id)
    {
        try
        {
            await _empresaRepositorio.DeleteAsync(id);
            return new CommandResult<object>(HttpStatusCode.OK.GetHashCode())
            {
                Mensagem = "Empresa excluída com sucesso!"
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
