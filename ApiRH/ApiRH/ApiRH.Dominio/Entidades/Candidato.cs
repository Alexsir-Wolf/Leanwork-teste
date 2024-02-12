using ApiRH.Dominio.Commands.Input.Candidatos;
using ApiRH.Dominio.Core.Data.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRH.Dominio.Entidades;

public class Candidato : EntidadeBase<int>
{
    public Candidato()
    {            
    }

    public Candidato(
        string? nome, 
        string? funcao,
        ICollection<CandidatoTecnologia> candidatoTecnologias)
    {
        Nome = nome;
        Funcao = funcao;
        CandidatoTecnologias = candidatoTecnologias;
    }

    [Column("CandidatoId")]
    public override int Id { get; set; }
    public string? Nome { get; set; }
    public string? Funcao { get; set; }

    public ICollection<CandidatoTecnologia>? CandidatoTecnologias { get; set; }

    public ICollection<VagaCandidato>? VagaCandidatos { get; set; }

    [NotMapped]
    public int? PesoTecnologiaVaga { get; set; }


    public Candidato MontarCandidato(CandidatoCommand command)
    {
        var tecnologias = new List<CandidatoTecnologia>();

        if (command.Tecnologias != null)
        {
            foreach (var tec in command.Tecnologias)
            {
                tecnologias.Add(new CandidatoTecnologia(tec.TecnologiaId));
            }
        }
        return new Candidato(
            command.Nome, 
            command.Funcao, 
            tecnologias);
    }

    public void MontaAlteracao(CandidatoCommand command)
	{
        var tecnologias = new List<CandidatoTecnologia>();

        if (command.Tecnologias != null)
        {
            foreach (var tec in command.Tecnologias)
            {
                tecnologias.Add(new CandidatoTecnologia(tec.TecnologiaId));
            }
        }

        Nome = command.Nome;
        Funcao = command.Funcao;
        CandidatoTecnologias = tecnologias;
	}
}
