using FormulaOne.Entities.Concrete;
using FormulaOne.DataAccess.Abstract;
using FormulaOne.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataAccess.Concrete.EntityFramework
{
    public class EfTeamDal : EfEntityRepositoryBase<Team, FormulaOneContext>, ITeamDal
    {

    }
}
