﻿using AutomatizacionApi.Context.Identity;
using AutomatizacionApi.Entities.Common;
using AutomatizacionApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutomatizacionApi.Repositories
{
    public class BaseRepository<TEntity, Tkey>(IdentityContext context) : IBaseRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly IdentityContext _context = context;
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public virtual async Task<TEntity> Delete(Tkey id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity!);
            await _context.SaveChangesAsync();
            return entity!;
        }

        public virtual async Task<TEntity?> GetById(Tkey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

    }
}
