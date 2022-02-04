using AutoMapper;
using FormulaOne.DataAccess.Models;
using FormulaOne.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataAccess.MapperProfiles
{
    public class RaceResultProfile : Profile
    {
        public RaceResultProfile()
        {
            CreateMap<RaceResult, RaceResultDto>();
            CreateMap<RaceResultDto, RaceResult>();
        }
    }
}
