using FormulaOne.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Concrete
{
    public class Team:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamChiefId { get; set; }
        public int CarId { get; set; }
    }
}
