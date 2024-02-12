using ApiRH.Dominio.Commands.Output.Candidatos;
using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Vagas;

public class VagaDetalheCommandResult
{
    public VagaDetalheCommandResult()
    {
    }

    public VagaDetalheCommandResult(
        int? vagaId,
        string? descricao,
        ICollection<TecnologiaDetalheCommandResult> tecnologias,
        ICollection<CandidatoDetalheCommandResult> candidatos,
        bool ativo)
    {
        VagaId = vagaId;
        Descricao = descricao;
        Tecnologias = tecnologias;
        Candidatos = candidatos;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? VagaId { get; private set; }
    public string? Descricao { get; private set; }
    public string? Status { get; private set; }

    public ICollection<TecnologiaDetalheCommandResult>? Tecnologias { get; set; }
    public ICollection<CandidatoDetalheCommandResult>? Candidatos { get; set; }

    public VagaDetalheCommandResult MontaVaga(Vaga? command)
    {
        var tecnologias = new List<TecnologiaDetalheCommandResult>();
        var candidatos = new List<CandidatoDetalheCommandResult>();

        if (command.VagaTecnologias != null)
            foreach (var tec in command.VagaTecnologias)
                tecnologias.Add(new TecnologiaDetalheCommandResult().MontarTecnologia(tec.Tecnologia));

        if (command.VagaCandidatos != null)
            foreach (var candidato in command.VagaCandidatos)
                candidatos.Add(new CandidatoDetalheCommandResult().MontarCandidato(candidato.Candidato));

        return new VagaDetalheCommandResult(
            command.Id,
            command.Descricao,
            tecnologias,
            candidatos,
            command.Ativo);
    }
}
