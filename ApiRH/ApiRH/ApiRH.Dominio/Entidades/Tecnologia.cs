using ApiRH.Dominio.Commands.Input.Tecnologias;
using ApiRH.Dominio.Commands.Input.Vagas;
using ApiRH.Dominio.Core.Data.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRH.Dominio.Entidades;

public class Tecnologia : EntidadeBase<int>
{
    public Tecnologia()
    {            
    }

    public Tecnologia(int id, int? peso)
    {
        Id = id;
        Peso = peso;
    }

    public Tecnologia(
        string? nome, 
        int? peso)
    {
        Nome = nome;
        Peso = peso;
    }

    public Tecnologia(string? nome)
    {
        Nome = nome;
    }

    [Column("TecnologiaId")]
    public override int Id { get; set; }
    public string? Nome { get; set; }
    public int? Peso { get; set; }

    public ICollection<EmpresaTecnologia> EmpresaTecnologias { get; set; }
    public ICollection<CandidatoTecnologia> CandidatoTecnologias { get; set; }
    public ICollection<VagaTecnologia> VagaTecnologias { get; set; }
    public ICollection<Vaga> Vagas { get; set; }


    public void MontaAlteracao(TecnologiaCommand command)
	{
		Nome = command.Nome;
	}

    public void MontaAlteracaoVagaTecnologia(VagaTecnologiaCommand command)
    {
        Peso = command.Peso;
    }
}
