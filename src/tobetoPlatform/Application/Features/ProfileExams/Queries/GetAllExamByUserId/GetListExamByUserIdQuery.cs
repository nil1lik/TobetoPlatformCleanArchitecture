using Application.Features.Exams.Queries.GetExamResaultDetailList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProfileExams.Queries.GetAllExamByUserId;
public class GetListExamByUserIdQuery : IRequest<GetListResponse<GetAllExamByUserIdResponse>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListExamByUserIdQueryHandler : IRequestHandler<GetListExamByUserIdQuery, GetListResponse<GetAllExamByUserIdResponse>>
    {
        private readonly IProfileExamRepository _profileExamRepository  ;
        private readonly IMapper _mapper;

        public GetListExamByUserIdQueryHandler(IProfileExamRepository profileExamRepository, IMapper mapper)
        {
            _profileExamRepository = profileExamRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetAllExamByUserIdResponse>> Handle(GetListExamByUserIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileExam> exams = await _profileExamRepository.GetListAsync(
                include: i => i.Include(x=>x.Exam).ThenInclude(x=>x.ExamResult),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetAllExamByUserIdResponse> response = _mapper.Map<GetListResponse<GetAllExamByUserIdResponse>>(exams);
            return response;
        }
    }
}
