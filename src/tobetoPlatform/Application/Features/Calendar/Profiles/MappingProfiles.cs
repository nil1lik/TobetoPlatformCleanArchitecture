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

namespace Application.Features.Calendar.Profiles;
public class MappingProfiles :  Profile
{
    public MappingProfiles() 
    {
        CreateMap<SyncLesson, GetByIdSyncLessonResponse>().ReverseMap();
        CreateMap<SyncLesson, GetListSyncLessonListItemDto>().ReverseMap();
        CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetListInstructorListItemDto>().ReverseMap();
    }
}
