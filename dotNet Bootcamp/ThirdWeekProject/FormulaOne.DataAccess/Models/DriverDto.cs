using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataAccess.Models
{
    public class DriverDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Nationality { get; set; }
        public int CarNumber { get; set; }
        public int TeamId { get; set; }
    }
}
