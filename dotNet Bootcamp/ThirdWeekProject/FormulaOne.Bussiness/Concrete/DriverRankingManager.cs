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
    public class DriverRankingManager : IDriverRankingService
    {
        private IDriverRankingDal _driverRankingDal;
        public DriverRankingManager(IDriverRankingDal driverRankingDal)
        {
            _driverRankingDal = driverRankingDal;
        }

        public List<DriverRanking> GetAll()
        {
            return _driverRankingDal.GetAll();
        }

        public void Add(DriverRanking driverRanking)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Add(driverRanking);
                context.SaveChanges();
            }
        }
        public void Update(DriverRanking driverRanking)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Update(driverRanking);
                context.SaveChanges();
            }
        }
        public void Delete(DriverRanking driverRanking)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Remove(driverRanking);
                context.SaveChanges();
            }
        }

        public DriverRanking Get(Expression<Func<DriverRanking, bool>> filter)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                return context.Set<DriverRanking>().SingleOrDefault(filter);
            }
        }


    }
}
