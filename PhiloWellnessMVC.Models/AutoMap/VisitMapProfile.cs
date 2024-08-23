using System;
using AutoMapper;
using PhiloWellnessMVC.Models.VisitModels;
using PhiloWellnessMVC.Data.Entities;

namespace PhiloWellnessMVC.Models.AutoMap
{
    public class VisitMapProfile : Profile
    {
        public VisitMapProfile()
        {
            CreateMap<VisitEntity, VisitDetailViewModel>();
            CreateMap<VisitEntity, VisitIndexViewModel>();
            CreateMap<VisitEntity, VisitEditViewModel>();

            CreateMap<VisitCreateViewModel, VisitEntity>();
            CreateMap<VisitEditViewModel, VisitEntity>();
        }
    }
}
