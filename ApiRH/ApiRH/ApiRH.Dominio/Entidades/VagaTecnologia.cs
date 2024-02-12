using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRH.Dominio.Entidades;

public class VagaTecnologia
{
    public VagaTecnologia(int? tecnologiaId)
    {
        TecnologiaId = tecnologiaId;
    }

    [Key, Column("VagaId")]
    public int? VagaId { get; set; }

    [ForeignKey("VagaId")]
    public Vaga? Vaga { get; set; }


    [Key, Column("TecnologiaId")]
    public int? TecnologiaId { get; set; }

    [ForeignKey("TecnologiaId")]
    public Tecnologia? Tecnologia { get; set; }
}
