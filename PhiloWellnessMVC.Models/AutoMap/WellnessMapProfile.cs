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
            CreateMap<WellnessEntity, WellnessDetailViewModel>();
            CreateMap<WellnessEntity, WellnessIndexViewModel>();
            CreateMap<WellnessEntity, WellnessEditViewModel>();

            CreateMap<WellnessCreateViewModel, WellnessEntity>();
            CreateMap<WellnessEditViewModel, WellnessEntity>();
        }
    }
}
