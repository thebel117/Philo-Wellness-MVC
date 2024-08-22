using System;
using AutoMapper;
using PhiloWellnessMVC.Models.WellnessModels;
using PhiloWellnessMVC.Data.Entities;

namespace PhiloWellnessMVC.Models.AutoMap
{
    public class WellnessMapProfile : Profile
    {
        public WellnessMapProfile()
        {
            CreateMap<WellnessEntity, WellnessDetail>();
            CreateMap<WellnessEntity, WellnessIndex>();
            CreateMap<WellnessEntity, WellnessEdit>();

            CreateMap<WellnessCreate, WellnessEntity>();
            CreateMap<WellnessEdit, WellnessEntity>();
        }
    }
}
