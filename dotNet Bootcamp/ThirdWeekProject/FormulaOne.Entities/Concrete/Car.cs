using FormulaOne.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Engine { get; set; }
        public string Chasis { get; set; }
    }
}
