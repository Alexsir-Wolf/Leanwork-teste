using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Vagas;

public class VagaTecnologiaCommandResult
{
    public VagaTecnologiaCommandResult()
    {
    }

    public VagaTecnologiaCommandResult(int? tecnologiaId)
    {
        TecnologiaId = tecnologiaId;
    }

    public VagaTecnologiaCommandResult(
        int? tecnologiaId,
        int? peso,
        bool ativo)
    {
        TecnologiaId = tecnologiaId;
        Peso = peso;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? TecnologiaId { get; private set; }
    public int? Peso { get; private set; }
    public string? Status { get; private set; }

    public VagaTecnologiaCommandResult MontaVagaTecnologia(Tecnologia? command)
    {
        return new VagaTecnologiaCommandResult(
            command.Id,
            command.Peso,
            command.Ativo);
    }

    public List<VagaTecnologiaCommandResult> MontarLista(IQueryable<Tecnologia> tecnologias)
    {
        var result = new List<VagaTecnologiaCommandResult>();

        foreach (var tec in tecnologias)
        {
            result.Add(new VagaTecnologiaCommandResult(
                tec.Id,
                tec.Peso,
                tec.Ativo));
        }
        return result;
    }
}