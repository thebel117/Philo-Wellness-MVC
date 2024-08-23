using System;
using AutoMapper;
using PhiloWellnessMVC.Models.StudentProfileModels;
using PhiloWellnessMVC.Data.Entities;

namespace PhiloWellnessMVC.Models.AutoMap
{
    public class StudentProfileMapProfile : Profile
    {
        public StudentProfileMapProfile()
        {
            CreateMap<StudentProfileEntity, StudentProfileDetailViewModel>();
            CreateMap<StudentProfileEntity, StudentProfileIndexViewModel>();
            CreateMap<StudentProfileEntity, StudentProfileEditViewModel>();

            CreateMap<StudentProfileCreateViewModel, StudentProfileEntity>();
            CreateMap<StudentProfileEditViewModel, StudentProfileEntity>();
        }
    }
}
