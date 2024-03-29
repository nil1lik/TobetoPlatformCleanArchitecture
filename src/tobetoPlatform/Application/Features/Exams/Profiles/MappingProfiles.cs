using Application.Features.Exams.Commands.Create;
using Application.Features.Exams.Commands.Delete;
using Application.Features.Exams.Commands.Update;
using Application.Features.Exams.Queries.GetById;
using Application.Features.Exams.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Exams.Queries.GetByIdExamResult;
using Application.Features.Exams.Queries.GetExamResaultDetailList;

namespace Application.Features.Exams.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Exam, CreateExamCommand>().ReverseMap();
        CreateMap<Exam, CreatedExamResponse>().ReverseMap();
        CreateMap<Exam, UpdateExamCommand>().ReverseMap();
        CreateMap<Exam, UpdatedExamResponse>().ReverseMap();
        CreateMap<Exam, DeleteExamCommand>().ReverseMap();
        CreateMap<Exam, DeletedExamResponse>().ReverseMap();
        CreateMap<Exam, GetByIdExamResponse>().ReverseMap();
        CreateMap<Exam, GetExamResultDetailDTO>().
            ForMember(x => x.ExamPoint, opt=>opt.MapFrom(x=>x.ExamResult.Point)).
            ForMember(x => x.ExamResultCreatedDate, opt=>opt.MapFrom(x=>x.ExamResult.CreatedDate)).
            ReverseMap();
        CreateMap<Exam, GetListExamListItemDto>().ReverseMap();
        CreateMap<Exam, GetExamResultDetailListDto>().
            ForMember(x => x.ExamPoint, opt => opt.MapFrom(x => x.ExamResult.Point)).
            ForMember(x => x.ExamResultCreatedDate, opt => opt.MapFrom(x => x.ExamResult.CreatedDate)).
            ReverseMap();
        CreateMap<IPaginate<Exam>, GetListResponse<GetListExamListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Exam>, GetListResponse<GetExamResultDetailListDto>>().ReverseMap();
    }
}