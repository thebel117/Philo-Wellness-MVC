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
            CreateMap<VisitEntity, VisitDetail>();
            CreateMap<VisitEntity, VisitIndex>();
            CreateMap<VisitEntity, VisitEdit>();

            CreateMap<VisitCreate, VisitEntity>();
            CreateMap<VisitEdit, VisitEntity>();
        }
    }
}
