using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRH.Dominio.Entidades;

public class VagaCandidato
{
    public VagaCandidato(int candidatoId)
    {
        CandidatoId = candidatoId;
    }

    [Key, Column("VagaId")]
    public int VagaId { get; set; }

    [ForeignKey("VagaId")]
    public Vaga? Vaga { get; set; }


    [Key, Column("CandidatoId")]
    public int CandidatoId { get; set; }

    [ForeignKey("CandidatoId")]
    public Candidato? Candidato { get; set; }
}
