using ApiRH.Dominio.Core.Commands.Contratos;
using Flunt.Notifications;

namespace ApiRH.Dominio.Core.Commands;

public class CommandResult<T> : NotifiableResult, ICommandResult<T>
{
    public CommandResult(int statusCode)
    {
        StatusCode = statusCode;
        Notificacoes = new List<Notification>();
    }

    public CommandResult(int statusCode,
        string mensagem) : this(statusCode)
    {
        Mensagem = mensagem;
    }


    public CommandResult(int statusCode,
        string mensagem,
        List<Notification> notificacoes) : this(statusCode,
        mensagem)
    {
        Notificacoes = notificacoes;
    }

    public CommandResult(int statusCode,
        string mensagem,
        List<Notification> notificacoes,
        T data) : this(statusCode, mensagem, notificacoes)
    {
        Data = data;
    }

    public int StatusCode { get; set; }
    public string Mensagem { get; set; }
    public T Data { get; set; }

}

