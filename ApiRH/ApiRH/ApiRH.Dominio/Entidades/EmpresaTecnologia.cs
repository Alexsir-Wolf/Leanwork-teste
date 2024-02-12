using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRH.Dominio.Entidades;

public class EmpresaTecnologia
{
    public EmpresaTecnologia(int tecnologiaId)
    {
        TecnologiaId = tecnologiaId;
    }

    [Key, Column("EmpresaId")]
    public int EmpresaId { get; set; }

    [ForeignKey("EmpresaId")]
    public Empresa? Empresa { get; set; }


    [Key, Column("TecnologiaId")]
    public int TecnologiaId { get; set; }

    [ForeignKey("TecnologiaId")]
    public Tecnologia? Tecnologia { get; set; }
}

