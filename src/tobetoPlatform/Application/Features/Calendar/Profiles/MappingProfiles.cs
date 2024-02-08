using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Features.SyncLessons.Queries.GetById;
using Application.Features.Instructors.Queries.GetById;
using Application.Features.SyncLessons.Queries.GetList;
using Application.Features.Instructors.Queries.GetList;
using Application.Features.Calendar.Queries.GetList;

namespace Application.Features.Calendar.Profiles;
public class MappingProfiles :  Profile
{
    public MappingProfiles() 
    {
        CreateMap<Instructor, GetListCalendarInstructorItemDto>().ReverseMap();
        CreateMap<CourseInstructor, GetListCalenderListItemDto>()
            .ForMember(x=>x.Instructor,opt=>opt.MapFrom(y=> y.Instructor))
            .ForMember(x=>x.CourseName,opt=>opt.MapFrom(x => x.Course.Name))
            .ForMember(x=>x.StartDate,opt=>opt.MapFrom(x => x.Course.SyncLessons.Select(x=>x.StartDate).FirstOrDefault()))
            .AfterMap((y, x) =>
            {
                x.Instructor.FirstName = y.Instructor.FirstName;
                x.Instructor.LastName = y.Instructor.LastName;
            })
            .ReverseMap();
    }
}
