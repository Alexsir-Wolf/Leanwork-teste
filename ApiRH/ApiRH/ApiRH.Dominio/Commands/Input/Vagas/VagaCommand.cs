using Flunt.Notifications;

namespace ApiRH.Dominio.Commands.Input.Vagas;

public class VagaCommand : Notifiable<Notification>
{
    public string? Descricao { get; set; }
    public ICollection<VagaTecnologiaCommand>? Tecnologias { get; set; }
    public ICollection<VagaCandidatoCommand>? Candidatos { get; set; }

    public new bool IsValid()
    {
        if (Descricao == null)
            AddNotification("Descricao", "Descrição é obrigatório!");

        return Notifications.Count <= 0;
    }
}
