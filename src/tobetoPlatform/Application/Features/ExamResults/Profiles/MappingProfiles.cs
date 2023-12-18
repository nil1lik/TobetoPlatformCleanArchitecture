using Application.Features.ExamResults.Commands.Create;
using Application.Features.ExamResults.Commands.Delete;
using Application.Features.ExamResults.Commands.Update;
using Application.Features.ExamResults.Queries.GetById;
using Application.Features.ExamResults.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ExamResults.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<ExamResult, CreateExamResultCommand>().ReverseMap();
        CreateMap<ExamResult, CreatedExamResultResponse>().ReverseMap();
        CreateMap<ExamResult, UpdateExamResultCommand>().ReverseMap();
        CreateMap<ExamResult, UpdatedExamResultResponse>().ReverseMap();
        CreateMap<ExamResult, DeleteExamResultCommand>().ReverseMap();
        CreateMap<ExamResult, DeletedExamResultResponse>().ReverseMap();
        CreateMap<ExamResult, GetByIdExamResultResponse>().ReverseMap();
        CreateMap<ExamResult, GetListExamResultListItemDto>().ReverseMap();
        CreateMap<IPaginate<ExamResult>, GetListResponse<GetListExamResultListItemDto>>().ReverseMap();
    }
}