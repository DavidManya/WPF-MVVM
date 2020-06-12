using System;
using System.Linq;
using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using Common.Lib.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AcademyMVVM.Lib.DAL
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ProjectDBContext _dbContext;

        public GenericRepository(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> DbSet
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }

        public virtual SaveResult<T> Add(T entity)
        {
            var output = new SaveResult<T>()
            {
                IsSuccess = true
            };

            if (entity.Id != default)
                throw new Exception("La entidad ya tiene id");

            entity.Id = Guid.NewGuid();
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            output.IsSuccess = true;
            output.Entity = entity;

            return output;
        }

        public T Find(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> QueryAll()
        {
            return DbSet.AsQueryable();
        }

        public virtual SaveResult<T> Update(T entity)
        {
            var output = new SaveResult<T>();

            if (entity.Id == default(Guid))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede actualizar una entidad sin Id");
            }

            if (entity.Id != default(Guid) && !DbSet.Any(x => x.Id == entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No existe una entity con ese id");
            }

            if (output.IsSuccess || DbSetContainsKey(entity.Id))
            {
                _dbContext.Set<T>().Update(entity);
                _dbContext.SaveChanges();
                output.IsSuccess = true;
            }

            return output;
        }

        public virtual SaveResult<T> Delete(T entity)
        {
            var output = new SaveResult<T>()
            {
                IsSuccess = true
            };


            if (DbSetContainsKey(entity.Id))
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
                output.IsSuccess = true;
            }

            else
            {
                output.IsSuccess = false;
            }

            return output;
        }

        public bool DbSetContainsKey(Guid id)
        {
            if (DbSet.Any(x => x.Id == id))
                return true;
            else
                return false;
        }

        IQueryable<T> IRepository<T>.QueryAll()
        {
            throw new NotImplementedException();
        }
    }
}
