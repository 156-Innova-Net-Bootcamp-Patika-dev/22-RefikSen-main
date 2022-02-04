using FormulaOne.DataAccess.Models;
using FormulaOne.Entities.Abstract;
using FormulaOne.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Business.Abstract
{
    public interface IRepositoryService<T> where T : IEntity
    {
        List<T> GetAll();
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public T Get(Expression<Func<T, bool>> filter);

    }
}
