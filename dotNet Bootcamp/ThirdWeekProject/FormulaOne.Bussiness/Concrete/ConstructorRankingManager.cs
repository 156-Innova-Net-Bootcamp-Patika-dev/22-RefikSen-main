using FormulaOne.DataAccess.Concrete.EntityFramework;
using FormulaOne.Entities.Concrete;
using FormulaOne.Business.Abstract;
using FormulaOne.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaOne.DataAccess.Models;
using System.Linq.Expressions;

namespace FormulaOne.Business.Concrete
{
    public class ConstructorRankingManager : IConstructorRankingService
    {
        private IConstructorRankingDal _constructorRankingDal;
        public ConstructorRankingManager(IConstructorRankingDal constructorRankingDal)
        {
            _constructorRankingDal = constructorRankingDal;
        }

        public List<ConstructorRanking> GetAll()
        {
            return _constructorRankingDal.GetAll();
        }

        public void Add(ConstructorRanking constructorRanking)
        {
            using (FormulaOneContext context = new())
            {
                context.Add(constructorRanking);
                context.SaveChanges();
            }
        }
        public void Update(ConstructorRanking constructorRanking)
        {
            using (FormulaOneContext context = new())
            {
                context.Update(constructorRanking);
                context.SaveChanges();
            }
        }
        public void Delete(ConstructorRanking constructorRanking)
        {
            using (FormulaOneContext context = new())
            {
                context.Remove(constructorRanking);
                context.SaveChanges();
            }
        }

        public ConstructorRanking Get(Expression<Func<ConstructorRanking, bool>> filter)
        {
            using (FormulaOneContext context = new())
            {
                return context.Set<ConstructorRanking>().SingleOrDefault(filter);
            }
        }


    }
}
