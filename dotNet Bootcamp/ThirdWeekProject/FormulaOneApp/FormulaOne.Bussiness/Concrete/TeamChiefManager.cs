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
    public class TeamChiefManager : ITeamChiefService
    {
        private ITeamChiefDal _teamChiefDal;
        public TeamChiefManager(ITeamChiefDal teamChiefDal)
        {
            _teamChiefDal = teamChiefDal;
        }

        public List<TeamChief> GetAll()
        {
            return _teamChiefDal.GetAll();
        }

        public void Add(TeamChief teamChief)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Add(teamChief);
                context.SaveChanges();
            }
        }
        public void Update(TeamChief teamChief)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Update(teamChief);
                context.SaveChanges();
            }
        }
        public void Delete(TeamChief teamChief)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Remove(teamChief);
                context.SaveChanges();
            }
        }

        public TeamChief Get(Expression<Func<TeamChief, bool>> filter)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                return context.Set<TeamChief>().SingleOrDefault(filter);
            }
        }


    }
}
