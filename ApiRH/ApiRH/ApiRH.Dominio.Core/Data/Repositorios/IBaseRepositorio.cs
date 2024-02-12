using ApiRH.Dominio.Core.Data.Entidades;
using System.Linq.Expressions;

namespace ApiRH.Dominio.Core.Data.Repositorios;

public interface IBaseRepositorio<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IEntidade<TKey>
{
    Task<IQueryable<TEntity>> ListarAsync();
    Task<TEntity?> ObterIdAsync(TKey id);
    Task InserirAsync(TEntity entity);
    Task UpdateAsync(TKey id, TEntity entity);
    Task DeleteAsync(TKey id);
    Task<IQueryable<TEntity>>ObterPorCondicaoAsync(Expression<Func<TEntity, bool>> expression, bool trackChanges = true);
}
