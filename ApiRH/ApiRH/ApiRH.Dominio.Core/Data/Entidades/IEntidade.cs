namespace ApiRH.Dominio.Core.Data.Entidades
{
    public interface IEntidade<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
