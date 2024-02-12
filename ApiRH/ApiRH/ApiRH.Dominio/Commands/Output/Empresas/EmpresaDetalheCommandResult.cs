using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Empresas;

public class EmpresaDetalheCommandResult
{
    public EmpresaDetalheCommandResult()
    {
    }

    public EmpresaDetalheCommandResult(
        int? empresaId,
        string? nome,
        string? cnpj,
        ICollection<TecnologiaCommandResult>? tecnologias,
        bool ativo)
    {
        EmpresaId = empresaId;
        Nome = nome;
        CNPJ = cnpj;
        Tecnologias = tecnologias;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? EmpresaId { get; private set; }
    public string? Nome { get; private set; }
    public string? CNPJ { get; private set; }
    public string? Status { get; private set; }
    public ICollection<TecnologiaCommandResult>? Tecnologias { get; set; }

    public EmpresaDetalheCommandResult MontarEmpresa(Empresa? empresa)
    {
        var tecnologias = new List<TecnologiaCommandResult>();

        if (empresa.EmpresaTecnologias != null)
            foreach (var tec in empresa.EmpresaTecnologias)
                tecnologias.Add(new TecnologiaCommandResult().MontaTecnologia(tec.Tecnologia));

        return new EmpresaDetalheCommandResult(
            empresa.Id,
            empresa.Nome,
            empresa.CNPJ,
            tecnologias,
            empresa.Ativo);
    }
}
