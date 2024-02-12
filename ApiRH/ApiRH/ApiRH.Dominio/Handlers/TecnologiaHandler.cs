using ApiRH.Dominio.Commands.Input.Tecnologias;
using ApiRH.Dominio.Commands.Input.Vagas;
using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Commands.Output.Vagas;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Entidades;
using System.Net;

namespace ApiRH.Dominio.Handlers;

public class TecnologiaHandler : ITecnologiaHandler
{
    private readonly ITecnologiaRepositorio _tecnologiaRepositorio;
    public TecnologiaHandler(ITecnologiaRepositorio tecnologiaRepositorio)
    {
        _tecnologiaRepositorio = tecnologiaRepositorio;
    }

    public async Task<CommandResult<TecnologiaCommandResult>> RegistrarTecnologia(TecnologiaCommand command) 
    {
        try
        {
            var result = new CommandResult<TecnologiaCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());

            if (!command.IsValid()) 
            {
                result.AddNotificacoes(command);
                return result;
            }

            var tecnologia = new Tecnologia(command.Nome);
            await _tecnologiaRepositorio.InserirAsync(tecnologia);

            return new CommandResult<TecnologiaCommandResult>(HttpStatusCode.Created.GetHashCode())
            {
                Data = new TecnologiaCommandResult().MontaTecnologia(tecnologia),
                Mensagem = "Tecnologia criada com sucesso!"
            };          
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<List<TecnologiaCommandResult>>> ListarTecnologias()
    {
        try
        {
            var tecnologias = await _tecnologiaRepositorio.ListarAsync();

            return new CommandResult<List<TecnologiaCommandResult>>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new TecnologiaCommandResult().MontarLista(tecnologias),
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<TecnologiaCommandResult>> AlterarTecnologia(int id, TecnologiaCommand command)
    {
        try
        {
            var result = new CommandResult<TecnologiaCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());
            if (!command.IsValid())
            {
                result.AddNotificacoes(command);
                return result;
            }

            var tecnologia = await _tecnologiaRepositorio.ObterIdAsync(Convert.ToInt32(id));
            tecnologia.MontaAlteracao(command);

            await _tecnologiaRepositorio.UpdateAsync(id, tecnologia);

            return new CommandResult<TecnologiaCommandResult>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new TecnologiaCommandResult().MontaTecnologia(tecnologia),
                Mensagem = "Tecnologia alterada com sucesso!"
            };
        }
        catch (Exception)
        {
            throw;
        }
    }   
    
    public async Task<CommandResult<VagaTecnologiaCommandResult>> AlterarVagaTecnologia(int id, VagaTecnologiaCommand command)
    {
        try
        {
            var result = new CommandResult<VagaTecnologiaCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());
            if (!command.IsValid())
            {
                result.AddNotificacoes(command);
                return result;
            }

            var tecnologia = await _tecnologiaRepositorio.ObterIdAsync(Convert.ToInt32(id));
            tecnologia.MontaAlteracaoVagaTecnologia(command);

            await _tecnologiaRepositorio.UpdateAsync(id, tecnologia);

            return new CommandResult<VagaTecnologiaCommandResult>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new VagaTecnologiaCommandResult().MontaVagaTecnologia(tecnologia),
                Mensagem = "Tecnologia alterada com sucesso!"
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<CommandResult<TecnologiaDetalheCommandResult>> ObterTecnologiaPorId(int id)
    {
        try
        {
            var tecnologia = await _tecnologiaRepositorio.ObterIdAsync(id);

            if (tecnologia != null)
            {
                return new CommandResult<TecnologiaDetalheCommandResult>(HttpStatusCode.OK.GetHashCode())
                {
                    Data = new TecnologiaDetalheCommandResult().MontarTecnologia(tecnologia),
                };
            }

            return new CommandResult<TecnologiaDetalheCommandResult>(HttpStatusCode.NotFound.GetHashCode())
            {
                Data = new TecnologiaDetalheCommandResult(),
                Mensagem = "Tecnologia não encontrada!"
            };            
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<object>> ExcluirTecnologia(int id)
    {
        try
        {
            await _tecnologiaRepositorio.DeleteAsync(id);
            return new CommandResult<object>(HttpStatusCode.OK.GetHashCode())
            {
                Mensagem = "Tecnologia excluída com sucesso!"
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
