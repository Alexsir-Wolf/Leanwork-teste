using ApiRH.Dominio.Commands.Input.Vagas;
using ApiRH.Dominio.Core.Data.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRH.Dominio.Entidades;

public class Vaga : EntidadeBase<int>
{
    public Vaga()
    {        
    }

    public Vaga(
        string? descricao, 
        ICollection<VagaTecnologia>? tecnologias, 
        ICollection<VagaCandidato>? candidatos)
    {
        Descricao = descricao;
        VagaTecnologias = tecnologias;
        VagaCandidatos = candidatos;
    }   
    
    public Vaga(
        string? descricao, 
        ICollection<VagaTecnologia>? vagaTecnologias, 
        ICollection<Tecnologia>? tecnologias, 
        ICollection<VagaCandidato>? candidatos)
    {
        Descricao = descricao;
        VagaTecnologias = vagaTecnologias;
        Tecnologias = tecnologias;
        VagaCandidatos = candidatos;
    }

    [Column("VagaId")]
    public override int Id { get; set; }
    public string? Descricao { get; set; }

    public ICollection<VagaTecnologia>? VagaTecnologias { get; set; }
    public ICollection<VagaCandidato>? VagaCandidatos { get; set; }
    public ICollection<Tecnologia>? Tecnologias { get; set; }

    public Vaga MontarVaga(VagaCommand command)
    {
        var vagaTecnologias = new List<VagaTecnologia>();
        var candidatos = new List<VagaCandidato>();

        if (command.Tecnologias != null)        
            foreach (var tec in command.Tecnologias)
                vagaTecnologias.Add(new VagaTecnologia(tec.TecnologiaId));

        if (command.Candidatos != null)        
            foreach (var candidato in command.Candidatos)           
                candidatos.Add(new VagaCandidato(candidato.CandidatoId));

        return new Vaga(
            command.Descricao,
            vagaTecnologias,            
            candidatos);
    }

    public void MontaAlteracao(VagaCommand command)
    {
        var tecnologias = new List<VagaTecnologia>();
        var candidatos = new List<VagaCandidato>();

        if (command.Tecnologias != null)        
            foreach (var tec in command.Tecnologias)            
                tecnologias.Add(new VagaTecnologia(tec.TecnologiaId));  

        if (command.Candidatos != null)        
            foreach (var candidato in command.Candidatos)            
                candidatos.Add(new VagaCandidato(candidato.CandidatoId));  

        Descricao = command.Descricao;
        VagaTecnologias = tecnologias;
        VagaCandidatos = candidatos;
    }
}
