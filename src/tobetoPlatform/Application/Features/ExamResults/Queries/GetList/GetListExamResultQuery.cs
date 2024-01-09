using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ExamResults.Queries.GetList;

public class GetListExamResultQuery : IRequest<GetListResponse<GetListExamResultListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListExamResultQueryHandler : IRequestHandler<GetListExamResultQuery, GetListResponse<GetListExamResultListItemDto>>
    {
        private readonly IExamResultRepository _examResultRepository;
        private readonly IMapper _mapper;

        public GetListExamResultQueryHandler(IExamResultRepository examResultRepository, IMapper mapper)
        {
            _examResultRepository = examResultRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListExamResultListItemDto>> Handle(GetListExamResultQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ExamResult> examResults = await _examResultRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListExamResultListItemDto> response = _mapper.Map<GetListResponse<GetListExamResultListItemDto>>(examResults);
            return response;
        }
    }
}