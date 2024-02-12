using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ApiRH.Dominio.Core.Data.Entidades;
using ApiRH.Dominio.Core.Data.Repositorios;
using ApiRH.Dominio;

namespace ApiRH.Infra.Data.Repositorios.Base;

public class BaseRepositorio<TEntity, TKey> : IBaseRepositorio<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IEntidade<TKey>
{
    private readonly ApiRHDbContext _dbContext; 

    public BaseRepositorio(ApiRHDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IQueryable<TEntity>> ListarAsync()
    {
        try
        {
            return await Task.Run(() => _dbContext.Set<TEntity>().AsNoTracking().Where(e => e.Ativo));
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<TEntity?> ObterIdAsync(TKey id)
    {
        try
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task InserirAsync(TEntity entity)
    {
        try
        {
            entity.Ativo = true;
            entity.DataCriacao = DateTime.Now;
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public virtual async Task UpdateAsync(TKey id, TEntity entity)
    {
        try
        {
            entity.DataAlteracao = DateTime.Now;
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public virtual async Task DeleteAsync(TKey id)
    {
        try
        {
            var entity = await ObterIdAsync(id);
            if (entity != null)
            {
                entity.Ativo = false;
                entity.DataAlteracao = DateTime.Now;
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<IQueryable<TEntity>> ObterPorCondicaoAsync(Expression<Func<TEntity, bool>> expression,
        bool trackChanges = true)
    {
        try
        {
            return await Task.Run(() => _dbContext.Set<TEntity>().Where(expression).AsNoTracking());
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}

