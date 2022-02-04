using FormulaOne.Entities.Concrete;
using FormulaOne.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataAccess.Concrete.EntityFramework
{
    public class EfTeamChiefDal : EfEntityRepositoryBase<TeamChief, FormulaOneContext>, ITeamChiefDal
    {

    }
}
