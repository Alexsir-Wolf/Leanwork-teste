using Flunt.Notifications;

namespace ApiRH.Dominio.Core.Commands;

public class NotifiableResult
{
    public List<Notification> Notificacoes { get; set; }
    public bool Sucesso { get { return Notificacoes == null || Notificacoes.Count == 0; } }

    public void AddNotificacao(string propriedade, string mensagem)
    {
        if (Notificacoes == null)
            Notificacoes = new List<Notification>();

        Notificacoes.Add(new Notification(propriedade, mensagem));
    }

    public void AddNotificacao(Notification notification)
    {
        if (notification == null)
            return;

        if (Notificacoes == null)
            Notificacoes = new List<Notification>();

        Notificacoes.Add(notification);
    }

    public void AddNotificacoes(ICollection<Notification> notifications)
    {
        if (notifications == null)
            return;

        if (Notificacoes == null)
            Notificacoes = new List<Notification>();

        Notificacoes.AddRange(notifications);
    }

    public void AddNotificacoes(Notifiable<Notification> item)
    {
        if (item == null)
            return;

        if (Notificacoes == null)
            Notificacoes = new List<Notification>();

        if (item.Notifications != null)
        {
            foreach (var notification in item.Notifications)
            {
                Notificacoes.Add(new Notification(notification.Key, notification.Message));
            }
        }
    }
}