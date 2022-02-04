using FormulaOne.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataAccess.Concrete.EntityFramework
{
    public class FormulaOneContext:DbContext
    {
          public DbSet<Car> Cars { get; set; }
          public DbSet<Circuit> Circuits { get; set; }
          public DbSet<ConstructorRanking> ConstructorRankings { get; set; }
          public DbSet<Driver> Drivers { get; set; }
          public DbSet<DriverRanking> DriverRankings { get; set; }
          public DbSet<QualifyingResult> QualifyingResults { get; set; }
          public DbSet<RaceResult> RaceResults { get; set; }
          public DbSet<Team> Teams { get; set; }
          public DbSet<TeamChief> TeamChiefs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;database=FormulaOne;Trusted_Connection=True;");
        }

        
    }

  
}
