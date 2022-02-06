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
using FormulaOne.Bussiness.Abstract.Common;

namespace FormulaOne.Business.Concrete
{
    public class QualifyingResultManager : RepositoryService<QualifyingResult>, IQualifyingResultService
    {
        public QualifyingResultManager(IEntityRepository<QualifyingResult> entityRepository) : base(entityRepository)
        {
        }
    }
}
