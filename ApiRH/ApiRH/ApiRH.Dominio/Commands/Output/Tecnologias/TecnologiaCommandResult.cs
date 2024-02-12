using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Tecnologias;

public class TecnologiaCommandResult
{
    public TecnologiaCommandResult()
    {
    }

    public TecnologiaCommandResult(int? tecnologiaId)
    {
        TecnologiaId = tecnologiaId;
    }

    public TecnologiaCommandResult(
        int? tecnologiaId,
        string? nome,
        bool ativo)
    {
        TecnologiaId = tecnologiaId;
        Nome = nome;
        Status = ativo ? "Ativo" : "Inativo";
    }  
    
    public TecnologiaCommandResult(
        int? tecnologiaId,
        string? nome,
        int? peso,
        bool ativo)
    {
        TecnologiaId = tecnologiaId;
        Nome = nome;
        Peso = peso;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? TecnologiaId { get; private set; }
    public string? Nome { get; private set; }
    public int? Peso { get; private set; }
    public string? Status { get; private set; }

    public TecnologiaCommandResult MontaTecnologia(Tecnologia? command)
    {
        return new TecnologiaCommandResult(
            command.Id,
            command.Nome, 
            command.Peso,
            command.Ativo);
    }

    public List<TecnologiaCommandResult> MontarLista(IQueryable<Tecnologia> tecnologias)
    {
        var result = new List<TecnologiaCommandResult>();

        foreach (var tec in tecnologias)
        {
            result.Add(new TecnologiaCommandResult(
                tec.Id,
                tec.Nome,
                tec.Ativo));
        }
        return result;
    }
}
