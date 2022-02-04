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
    public class DriverManager : IDriverService
    {
        private IDriverDal _driverDal;
        public DriverManager(IDriverDal driverDal)
        {
            _driverDal = driverDal;
        }

        public List<Driver> GetAll()
        {
            return _driverDal.GetAll();
        }

        public void Add(Driver driver)
        {
            using (FormulaOneContext context = new())
            {
                context.Add(driver);
                context.SaveChanges();
            }
        }
        public void Update(Driver driver)
        {
            using (FormulaOneContext context = new())
            {
                context.Update(driver);
                context.SaveChanges();
            }
        }
        public void Delete(Driver driver)
        {
            using (FormulaOneContext context = new())
            {
                context.Remove(driver);
                context.SaveChanges();
            }
        }

        public Driver Get(Expression<Func<Driver, bool>> filter)
        {
            using (FormulaOneContext context = new())
            {
                return context.Set<Driver>().SingleOrDefault(filter);
            }
        }


    }
}
