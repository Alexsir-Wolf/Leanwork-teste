namespace ApiRH.Dominio.Core.Data.Entidades;

public abstract class EntidadeBase<TKey> : IEntidade<TKey> where TKey : IEquatable<TKey>
{
    public EntidadeBase()
    {
        DataCriacao = DateTime.Now;
    }

    public EntidadeBase(TKey id)
    {
        Id = id;
    }

    public abstract TKey Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public virtual bool Ativo { get; set; } = true;
}
