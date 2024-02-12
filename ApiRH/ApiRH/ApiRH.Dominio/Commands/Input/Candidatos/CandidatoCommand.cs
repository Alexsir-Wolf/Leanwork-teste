using ApiRH.Dominio.Commands.Input.Empresas;
using Flunt.Notifications;

namespace ApiRH.Dominio.Commands.Input.Candidatos;

public class CandidatoCommand : Notifiable<Notification>
{
    public string? Nome { get; set; }
    public string? Funcao { get; set; }

    public ICollection<CandidatoTecnologiaCommand>? Tecnologias { get; set; }

    public new bool IsValid()
    {
        if (Nome == null)
            AddNotification("Nome", "Nome é obrigatório!");     
        
        if (Funcao == null)
            AddNotification("Funcao", "Função é obrigatório!");

        return Notifications.Count <= 0;
    }
}
