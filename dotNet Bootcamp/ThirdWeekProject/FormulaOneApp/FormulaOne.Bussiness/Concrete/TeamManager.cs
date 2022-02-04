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
    public class TeamManager : ITeamService
    {
        private ITeamDal _teamDal;
        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public List<Team> GetAll()
        {
            return _teamDal.GetAll();
        }

        public void Add(Team team)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Add(team);
                context.SaveChanges();
            }
        }
        public void Update(Team team)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Update(team);
                context.SaveChanges();
            }
        }
        public void Delete(Team team)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                context.Remove(team);
                context.SaveChanges();
            }
        }

        public Team Get(Expression<Func<Team, bool>> filter)
        {
            using (FormulaOneContext context = new FormulaOneContext())
            {
                return context.Set<Team>().SingleOrDefault(filter);
            }
        }


    }
}
