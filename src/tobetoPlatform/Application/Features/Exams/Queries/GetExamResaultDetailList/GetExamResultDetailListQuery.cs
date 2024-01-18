using Amazon.Runtime.Internal;
using Application.Features.Exams.Queries.GetList;
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

namespace Application.Features.Exams.Queries.GetExamResaultDetailList;
public class GetExamResultDetailListQuery : IRequest<GetListResponse<GetExamResultDetailListDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetExamResultDetailListQueryHandler : IRequestHandler<GetExamResultDetailListQuery, GetListResponse<GetExamResultDetailListDto>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public GetExamResultDetailListQueryHandler(IExamRepository examRepository, IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetExamResultDetailListDto>> Handle(GetExamResultDetailListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Exam> exams = await _examRepository.GetListAsync(
                include: i => i.Include(i => i.ExamResult),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetExamResultDetailListDto> response = _mapper.Map<GetListResponse<GetExamResultDetailListDto>>(exams);
            return response;
        }
    }
}
