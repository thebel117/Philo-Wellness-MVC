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
            CreateMap<StudentProfileEntity, StudentProfileDetail>();
            CreateMap<StudentProfileEntity, StudentProfileIndex>();
            CreateMap<StudentProfileEntity, StudentProfileEdit>();

            CreateMap<StudentProfileCreate, StudentProfileEntity>();
            CreateMap<StudentProfileEdit, StudentProfileEntity>();
        }
    }
}
