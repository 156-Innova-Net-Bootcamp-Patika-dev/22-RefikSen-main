using FormulaOne.Business.Abstract;
using FormulaOne.DataAccess.Abstract;
using FormulaOne.DataAccess.Concrete.EntityFramework;
using FormulaOne.Entities.Abstract;
using FormulaOne.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Bussiness.Abstract.Common
{
    public class RepositoryService<T> : IRepositoryService<T> where T : IEntity
    {
        private readonly IEntityRepository<T> _entityRepository;
        public RepositoryService(IEntityRepository<T> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<T> GetAll()
        {
            return _entityRepository.GetAll();
        }

        public void Add(T entity)
        {
            using FormulaOneContext context = new();
                context.Add(entity);
                context.SaveChanges();
        }

        public void Update(T entity)
        {
            using FormulaOneContext context = new();      
                context.Update(entity);
                context.SaveChanges();            
        }

        public void Delete(T entity)
        {
            using FormulaOneContext context = new();            
                context.Remove(entity);
                context.SaveChanges();            
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using FormulaOneContext context = new();            
                return context.Set<T>().SingleOrDefault(filter);            
        }




    }
}
