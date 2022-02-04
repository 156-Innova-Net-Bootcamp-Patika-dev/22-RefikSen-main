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
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add(Car car)
        {
            using FormulaOneContext context = new();           
                context.Add(car);
                context.SaveChanges();
            
        }
        public void Update(Car car)
        {
            using (FormulaOneContext context = new())
            {
                context.Update(car);
                context.SaveChanges();
            }
        }
        public void Delete(Car car)
        {
            using (FormulaOneContext context = new())
            {
                context.Remove(car);
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (FormulaOneContext context = new())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }


    }
}
