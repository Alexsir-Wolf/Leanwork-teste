using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Tecnologias;

public class TecnologiaDetalheCommandResult
{
    public TecnologiaDetalheCommandResult()
    {            
    }

    public TecnologiaDetalheCommandResult(int? tecnologiaId)
    {
        TecnologiaId = tecnologiaId;
    }

    public TecnologiaDetalheCommandResult(
        int? tecnologiaId,
        string? nome,
        bool ativo)
    {
        TecnologiaId = tecnologiaId;
        Nome = nome;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? TecnologiaId { get; private set; }
    public string? Nome { get; private set; }
    public string? Status { get; private set; }

    public TecnologiaDetalheCommandResult MontarTecnologia(Tecnologia tecnologia)
    {
        return new TecnologiaDetalheCommandResult(
            tecnologia.Id,
            tecnologia.Nome,
            tecnologia.Ativo);
    }
}
