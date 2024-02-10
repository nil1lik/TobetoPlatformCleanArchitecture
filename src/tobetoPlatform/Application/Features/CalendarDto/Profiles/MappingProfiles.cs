//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Domain.Entities;
//using Application.Features.SyncLessons.Queries.GetById;
//using Application.Features.Instructors.Queries.GetById;
//using Application.Features.SyncLessons.Queries.GetList;
//using Application.Features.Instructors.Queries.GetList;
//using Application.Features.Calendar.Queries.GetList;
//using Application.Features.Cities.Queries.GetList;
//using Core.Application.Responses;
//using Core.Persistence.Paging;

//namespace Application.Features.Calendar.Profiles;
//public class MappingProfiles :  Profile
//{
//    public MappingProfiles() 
//    {
//        CreateMap<Course, GetListCalenderListItemDto>()
//            .ForMember(x=>x.EducationPathName,opt=>opt.MapFrom(x => x.EducationPath.Name))
//            .ForMember(x=>x.StartDate,opt=>opt.MapFrom(x=>x.SyncLessons.Select(x=>x.StartDate).FirstOrDefault()))
//            .ForMember(x=>x.FirstName,opt=>opt.MapFrom(x=>x.CourseInstructors.Select(x=>x.Instructor.FirstName).FirstOrDefault()))
//            .ForMember(x=>x.LastName,opt=>opt.MapFrom(x=>x.CourseInstructors.Select(x=>x.Instructor.LastName).FirstOrDefault()))
//            .ReverseMap();
//        CreateMap<IPaginate<Course>, GetListResponse<GetListCalenderListItemDto>>().ReverseMap();

//    }
//}
