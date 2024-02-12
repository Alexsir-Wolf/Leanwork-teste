using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Empresas;

public class EmpresaCommandResult
{
    public EmpresaCommandResult()
    {
    }

    public EmpresaCommandResult(
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

    public EmpresaCommandResult MontarEmpresa(Empresa? empresa)
    {
        var tecnologias = new List<TecnologiaCommandResult>();

        if (empresa.EmpresaTecnologias != null)
            foreach (var tec in empresa.EmpresaTecnologias)
                if (tec.Tecnologia != null)
                    tecnologias.Add(new TecnologiaCommandResult().MontaTecnologia(tec.Tecnologia));
                else
                    tecnologias.Add(new TecnologiaCommandResult(tec.TecnologiaId));

        return new EmpresaCommandResult(
            empresa.Id,
            empresa.Nome,
            empresa.CNPJ,
            tecnologias,
            empresa.Ativo);
    }

    public List<EmpresaCommandResult> MontarLista(ICollection<Empresa>? empresas)
    {
        var result = new List<EmpresaCommandResult>();
        var tecnologias = new List<TecnologiaCommandResult>();

        if (empresas != null)        
            foreach (var empresa in empresas)
            {
                if (empresa.EmpresaTecnologias != null)
                    foreach (var tec in empresa.EmpresaTecnologias)
                        if (tec.Tecnologia != null)
                            tecnologias.Add(new TecnologiaCommandResult().MontaTecnologia(tec.Tecnologia));
                        else
                            tecnologias.Add(new TecnologiaCommandResult(tec.TecnologiaId));

                result.Add(new EmpresaCommandResult(
                    empresa.Id,
                    empresa.Nome,
                    empresa.CNPJ,
                    tecnologias,
                    empresa.Ativo));
            }        
        return result;
    }
}
