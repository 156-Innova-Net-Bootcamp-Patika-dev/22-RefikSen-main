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
    public class RaceResultManager : IRaceResultService
    {
        private IRaceResultDal _raceResultDal;
        public RaceResultManager(IRaceResultDal raceResultDal)
        {
            _raceResultDal = raceResultDal;
        }

        public List<RaceResult> GetAll()
        {
            return _raceResultDal.GetAll();
        }

        public void Add(RaceResult raceResult)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Add(raceResult);
                context.SaveChanges();
            }
        }
        public void Update(RaceResult raceResult)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Update(raceResult);
                context.SaveChanges();
            }
        }
        public void Delete(RaceResult raceResult)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Remove(raceResult);
                context.SaveChanges();
            }
        }

        public RaceResult Get(Expression<Func<RaceResult, bool>> filter)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                return context.Set<RaceResult>().SingleOrDefault(filter);
            }
        }


    }
}
