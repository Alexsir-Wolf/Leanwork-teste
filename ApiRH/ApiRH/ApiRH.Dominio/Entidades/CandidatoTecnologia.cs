using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRH.Dominio.Entidades;

public class CandidatoTecnologia
{
    public CandidatoTecnologia(int tecnologiaId)
    {
        TecnologiaId = tecnologiaId;
    }

    [Key, Column("CandidatoId")]
    public int CandidatoId { get; set; }

    [ForeignKey("CandidatoId")]
    public Candidato? Candidato { get; set; }


    [Key, Column("TecnologiaId")]
    public int TecnologiaId { get; set; }

    [ForeignKey("TecnologiaId")]
    public Tecnologia? Tecnologia { get; set; }
}

