using Kanban.Model.Entities;
using Kanban.Model.Shared.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Repository.Collections
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly KanbanDBContext _context;

        public IQueryable<TEntity> Queryable => _context.Set<TEntity>().AsQueryable();

        public GenericRepository(KanbanDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsyn() => await _context.Set<TEntity>().ToListAsync();

        public  async Task<TEntity> GetAsyn(int? id) => await _context.Set<TEntity>().FindAsync(id);

        public  async Task<TEntity> AddAsyn(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public  async Task<int> DeleteAsyn(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public  async Task<TEntity> UpdateAsyn(TEntity entity, object key)
        {
            if (entity == null)
                return null;

            TEntity exist = await _context.Set<TEntity>().FindAsync(key);

            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

            return exist;
        }

        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>();

        public TEntity Get(int? id) => _context.Set<TEntity>().Find(id);

        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public void Delete(int id)
        {
            try
            {
                TEntity tentity = _context.Set<TEntity>().Find(id);
                _context.Set<TEntity>().Remove(tentity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
