namespace ApiRH.Dominio.Core.Commands.Contratos;

public interface ICommandResult<T>
{
    public string Mensagem { get; set; }
    public T Data { get; set; }
}