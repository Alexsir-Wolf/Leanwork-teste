using ApiRH.Dominio.Commands.Input.Candidatos;
using ApiRH.Dominio.Commands.Output.Candidatos;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Entidades;
using System.Net;

namespace ApiRH.Dominio.Handlers;

public class CandidatoHandler : ICandidatoHandler
{
    private readonly ICandidatoRepositorio _candidatoRepositorio;
    private readonly IVagaRepositorio _vagaRepositorio;
    public CandidatoHandler(ICandidatoRepositorio candidatoRepositorio, IVagaRepositorio vagaRepositorio)
    {
        _candidatoRepositorio = candidatoRepositorio;
        _vagaRepositorio = vagaRepositorio;
    }

    public async Task<CommandResult<CandidatoCommandResult>> RegistrarCandidato(CandidatoCommand command) 
    {
        try
        {
            var result = new CommandResult<CandidatoCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());

            if (!command.IsValid()) 
            {
                result.AddNotificacoes(command);
                return result;
            }

            var candidato = new Candidato().MontarCandidato(command);
            await _candidatoRepositorio.InserirAsync(candidato);

            return new CommandResult<CandidatoCommandResult>(HttpStatusCode.Created.GetHashCode())
            {
                Data = new CandidatoCommandResult().MontaCandidato(candidato),
                Mensagem = "Candidato criado com sucesso!"
            };          
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<List<CandidatoCommandResult>>> ListarCandidatos()
    {
        try
        {
            var candidatos = await _candidatoRepositorio.ListarCandidatos();

            return new CommandResult<List<CandidatoCommandResult>>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new CandidatoCommandResult().MontarLista(candidatos),
            };
        }
        catch (Exception)
        {
            throw;
        }
    }    
    
    public async Task<CommandResult<List<CandidatoCommandResult>>> ListarCandidatosPorVaga(int id)
    {
        try
        {
            //Obter candidatos
            var candidatos = await _candidatoRepositorio.ListarCandidatosPorVaga(id);

            foreach (var item in candidatos)
            {
                var peso = item.CandidatoTecnologias.Select(x => x.Tecnologia).Sum(x => x.Peso);
                item.PesoTecnologiaVaga = peso;
            }

  

            return new CommandResult<List<CandidatoCommandResult>>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new CandidatoCommandResult().MontarListaPorPeso(candidatos)
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<CandidatoCommandResult>> AlterarCandidato(int id, CandidatoCommand command)
    {
        try
        {
            var result = new CommandResult<CandidatoCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());
            if (!command.IsValid())
            {
                result.AddNotificacoes(command);
                return result;
            }

            var candidato = await _candidatoRepositorio.ObterCandidatoPorId(Convert.ToInt32(id));
            candidato.MontaAlteracao(command);

            await _candidatoRepositorio.AlterarCandidato(id, candidato);

            return new CommandResult<CandidatoCommandResult>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new CandidatoCommandResult().MontaCandidato(candidato),
                Mensagem = "Candidato alterado com sucesso!"
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<CommandResult<CandidatoDetalheCommandResult>> ObterCandidatoPorId(int id)
    {
        try
        {
            var candidato = await _candidatoRepositorio.ObterCandidatoPorId(id);

            if (candidato != null)
            {
                return new CommandResult<CandidatoDetalheCommandResult>(HttpStatusCode.OK.GetHashCode())
                {
                    Data = new CandidatoDetalheCommandResult().MontarCandidato(candidato),
                };
            }

            return new CommandResult<CandidatoDetalheCommandResult>(HttpStatusCode.NotFound.GetHashCode())
            {
                Data = new CandidatoDetalheCommandResult(),
                Mensagem = "Candidato não encontrado!"
            };            
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<object>> ExcluirCandidato(int id)
    {
        try
        {
            await _candidatoRepositorio.DeleteAsync(id);
            return new CommandResult<object>(HttpStatusCode.OK.GetHashCode())
            {
                Mensagem = "Candidato excluído com sucesso!"
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
