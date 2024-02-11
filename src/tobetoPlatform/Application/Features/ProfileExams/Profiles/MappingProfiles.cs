using Application.Features.ProfileExams.Commands.Create;
using Application.Features.ProfileExams.Commands.Delete;
using Application.Features.ProfileExams.Commands.Update;
using Application.Features.ProfileExams.Queries.GetById;
using Application.Features.ProfileExams.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.ProfileExams.Queries.GetAllExamByUserId;

namespace Application.Features.ProfileExams.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileExam, CreateProfileExamCommand>().ReverseMap();
        CreateMap<ProfileExam, CreatedProfileExamResponse>().ReverseMap();
        CreateMap<ProfileExam, UpdateProfileExamCommand>().ReverseMap();
        CreateMap<ProfileExam, UpdatedProfileExamResponse>().ReverseMap();
        CreateMap<ProfileExam, DeleteProfileExamCommand>().ReverseMap();
        CreateMap<ProfileExam, DeletedProfileExamResponse>().ReverseMap();
        CreateMap<ProfileExam, GetByIdProfileExamResponse>().ReverseMap();
        CreateMap<ProfileExam, GetListProfileExamListItemDto>().ReverseMap();
        CreateMap<ProfileExam, GetAllExamByUserIdResponse>()
            .ForMember(x=>x.Name,opt=>opt.MapFrom(x=>x.Exam.Name))
            .ForMember(x=>x.ExamPoint,opt=>opt.MapFrom(x=>x.Exam.ExamResult.Point))
            .ForMember(x=>x.ExamResultCreatedDate,opt=>opt.MapFrom(x=>x.Exam.ExamResult.CreatedDate))
            .ReverseMap();
        CreateMap<IPaginate<ProfileExam>, GetListResponse<GetListProfileExamListItemDto>>().ReverseMap();
        CreateMap<IPaginate<ProfileExam>, GetListResponse<GetAllExamByUserIdResponse>>().ReverseMap();
    }
}