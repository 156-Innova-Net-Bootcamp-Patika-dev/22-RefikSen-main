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
    public class QualifyingResultManager : IQualifyingResultService
    {
        private IQualifyingResultDal _qualifyingResultDal;
        public QualifyingResultManager(IQualifyingResultDal qualifyingResultDal)
        {
            _qualifyingResultDal = qualifyingResultDal;
        }

        public List<QualifyingResult> GetAll()
        {
            return _qualifyingResultDal.GetAll();
        }

        public void Add(QualifyingResult qualifyingResult)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Add(qualifyingResult);
                context.SaveChanges();
            }
        }
        public void Update(QualifyingResult qualifyingResult)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Update(qualifyingResult);
                context.SaveChanges();
            }
        }
        public void Delete(QualifyingResult qualifyingResult)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Remove(qualifyingResult);
                context.SaveChanges();
            }
        }

        public QualifyingResult Get(Expression<Func<QualifyingResult, bool>> filter)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                return context.Set<QualifyingResult>().SingleOrDefault(filter);
            }
        }


    }
}
