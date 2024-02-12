using Flunt.Notifications;

namespace ApiRH.Dominio.Commands.Input.Vagas;

public class VagaTecnologiaCommand : Notifiable<Notification>
{
    public int? TecnologiaId { get; set; }
    public int? Peso { get; set; }

    public new bool IsValid()
    {
        if (TecnologiaId == null)
            AddNotification("TecnologiaId", "Tecnologia é obrigatório!");

        if (Peso == null)
            AddNotification("Peso", "Peso é obrigatório!");

        return Notifications.Count <= 0;
    }
}
