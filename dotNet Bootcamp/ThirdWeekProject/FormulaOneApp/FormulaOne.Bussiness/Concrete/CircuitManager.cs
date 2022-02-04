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
    public class CircuitManager : ICircuitService
    {
        private ICircuitDal _circuitDal;
        public CircuitManager(ICircuitDal circuitDal)
        {
            _circuitDal = circuitDal;
        }

        public List<Circuit> GetAll()
        {
            return _circuitDal.GetAll();
        }

        public void Add(Circuit circuit)
        {
            using (FormulaOneContext context = new())
            {
                context.Add(circuit);
                context.SaveChanges();
            }
        }
        public void Update(Circuit circuit)
        {
            using (FormulaOneContext context = new())
            {
                context.Update(circuit);
                context.SaveChanges();
            }
        }
        public void Delete(Circuit circuit)
        {
            using (FormulaOneContext context = new())
            {
                context.Remove(circuit);
                context.SaveChanges();
            }
        }

        public Circuit Get(Expression<Func<Circuit, bool>> filter)
        {
            using (FormulaOneContext context = new())
            {
                return context.Set<Circuit>().SingleOrDefault(filter);
            }
        }


    }
}
