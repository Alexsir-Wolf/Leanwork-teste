using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiRH.Dominio.Commands.Output.Candidatos;

public class CandidatoDetalheCommandResult
{
    public CandidatoDetalheCommandResult()
    {
    }

    public CandidatoDetalheCommandResult(
        int? candidatoId,
        string? nome,
        string? funcao,
        ICollection<TecnologiaDetalheCommandResult> tecnologias,
        bool ativo)
    {
        CandidatoId = candidatoId;
        Nome = nome;
        Funcao = funcao;
        Tecnologias = tecnologias;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? CandidatoId { get; private set; }
    public string? Nome { get; private set; }
    public string? Funcao { get; private set; }
    public string? Status { get; private set; }

    public ICollection<TecnologiaDetalheCommandResult>? Tecnologias { get; set; }

    public CandidatoDetalheCommandResult MontarCandidato(Candidato candidato)
    {
        var tecnologias = new List<TecnologiaDetalheCommandResult>();

        if (candidato.CandidatoTecnologias != null)
            foreach (var tec in candidato.CandidatoTecnologias)
                tecnologias.Add(new TecnologiaDetalheCommandResult().MontarTecnologia(tec.Tecnologia));

        return new CandidatoDetalheCommandResult(
            candidato.Id,
            candidato.Nome,
            candidato.Funcao,
            tecnologias,
            candidato.Ativo);
    }
}
