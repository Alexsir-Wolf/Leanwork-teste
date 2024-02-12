using ApiRH.Dominio.Commands.Input.Empresas;
using ApiRH.Dominio.Core.Data.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRH.Dominio.Entidades;

public class Empresa : EntidadeBase<int>
{
    public Empresa()
    {            
    }

    public Empresa(
        string? nome, 
        string? cnpj,
        ICollection<EmpresaTecnologia>? empresaTecnologia)
    {
        Nome = nome;
        CNPJ = cnpj;
        EmpresaTecnologias = empresaTecnologia;
    }

    [Column("EmpresaId")]
    public override int Id { get; set; }
    public string? Nome { get; set; }
    public string? CNPJ { get; set; }
    public ICollection<EmpresaTecnologia>? EmpresaTecnologias { get; set; }

    public Empresa MontarEmpresa(EmpresaCommand command)
    {
        var tecnologias = new List<EmpresaTecnologia>();

        if (command.Tecnologias != null)
        {
            foreach (var tec in command.Tecnologias)
            {
                tecnologias.Add(new EmpresaTecnologia(tec.TecnologiaId));
            }
        } 
        return new Empresa(command.Nome, command.CNPJ, tecnologias);
    }

    public void MontaAlteracao(EmpresaCommand command)
	{
        var tecnologias = new List<EmpresaTecnologia>();

        if (command.Tecnologias != null)
        {
            foreach (var tec in command.Tecnologias)
            {
                tecnologias.Add(new EmpresaTecnologia(tec.TecnologiaId));
            }
        }

        Nome = command.Nome;
        CNPJ = command.CNPJ;
        EmpresaTecnologias = tecnologias;
	}
}
