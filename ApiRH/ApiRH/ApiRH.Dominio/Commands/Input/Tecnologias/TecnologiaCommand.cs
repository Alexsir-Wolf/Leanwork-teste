using Flunt.Notifications;

namespace ApiRH.Dominio.Commands.Input.Tecnologias;

public class TecnologiaCommand : Notifiable<Notification>
{
    public string? Nome { get; set; }

    public new bool IsValid()
    {
        if (Nome == null)
            AddNotification("Nome", "Nome é obrigatório!");

        return Notifications.Count <= 0;
    }
}
