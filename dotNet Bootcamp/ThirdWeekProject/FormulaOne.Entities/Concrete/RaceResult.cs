using FormulaOne.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Concrete
{
    public class RaceResult:IEntity
    {
        public int Id { get; set; }
        public int CircuitId { get; set; }
        public int DriverId { get; set; }
        public int Position { get; set; }
        public int CompletedLaps { get; set; }
    }
}
