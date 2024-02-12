using ApiRH.Dominio.Commands.Output.Candidatos;
using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Vagas;

public class VagaCommandResult
{
    public VagaCommandResult()
    {
    }

    public VagaCommandResult(int? vagaId)
    {
        VagaId = vagaId;
    }

    public VagaCommandResult(
        int? vagaId,
        string? descricao,
        ICollection<TecnologiaCommandResult> tecnologias,
        ICollection<CandidatoCommandResult> candidatos,
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

    public ICollection<TecnologiaCommandResult>? Tecnologias { get; set; }
    public ICollection<CandidatoCommandResult>? Candidatos { get; set; }

    public VagaCommandResult MontaVaga(Vaga? command)
    {
        var tecnologias = new List<TecnologiaCommandResult>();
        var candidatos = new List<CandidatoCommandResult>();

        if (command.VagaTecnologias != null)
            foreach (var tec in command.VagaTecnologias)
                if (tec.Tecnologia != null)
                    tecnologias.Add(new TecnologiaCommandResult().MontaTecnologia(tec.Tecnologia));             
                else
                    tecnologias.Add(new TecnologiaCommandResult(tec.TecnologiaId));             
        
        if (command.VagaCandidatos != null)
            foreach (var candidato in command.VagaCandidatos)
                if (candidato.Candidato != null)
                    candidatos.Add(new CandidatoCommandResult().MontaCandidato(candidato.Candidato));
                else
                    candidatos.Add(new CandidatoCommandResult(candidato.CandidatoId));

        return new VagaCommandResult(
            command.Id,
            command.Descricao,
            tecnologias,
            candidatos,
            command.Ativo);
    }

    public List<VagaCommandResult> MontarLista(ICollection<Vaga> vagas)
    {
        var result = new List<VagaCommandResult>();

        foreach (var vaga in vagas)        
            result.Add(new VagaCommandResult().MontaVaga(vaga));       

        return result;
    }
}
