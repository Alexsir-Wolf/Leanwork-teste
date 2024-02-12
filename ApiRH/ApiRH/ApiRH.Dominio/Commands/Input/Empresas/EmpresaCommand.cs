using Flunt.Notifications;

namespace ApiRH.Dominio.Commands.Input.Empresas;

public class EmpresaCommand : Notifiable<Notification>
{
    public string? Nome { get; set; }
    public string? CNPJ { get; set; }
    public ICollection<EmpresaTecnologiaCommand>? Tecnologias { get; set; }

    public new bool IsValid()
    {
        if (Nome == null)
            AddNotification("Nome", "Nome é obrigatório!");

        if (CNPJ == null)
            AddNotification("CNPJ", "CNPJ é obrigatório!");

        return Notifications.Count <= 0;
    }

}
