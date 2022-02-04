using FormulaOne.DataAccess.Abstract;
using FormulaOne.DataAccess.Concrete.EntityFramework;
using FormulaOne.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataAccess.Concrete.EntityFramework
{
    public class EfConstructorRankingDal : EfEntityRepositoryBase<ConstructorRanking, FormulaOneContext>, IConstructorRankingDal
    {

    }
}
