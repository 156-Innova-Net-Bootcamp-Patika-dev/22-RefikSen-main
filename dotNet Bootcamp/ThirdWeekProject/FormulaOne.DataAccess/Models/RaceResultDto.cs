using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataAccess.Models
{
    public class RaceResultDto
    {
        public int CircuitId { get; set; }
        public int DriverId { get; set; }
        public int Position { get; set; }
        public int CompletedLaps { get; set; }
    }
}
