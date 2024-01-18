using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileExams.Queries.GetList;

public class GetListProfileExamQuery : IRequest<GetListResponse<GetListProfileExamListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileExamQueryHandler : IRequestHandler<GetListProfileExamQuery, GetListResponse<GetListProfileExamListItemDto>>
    {
        private readonly IProfileExamRepository _profileExamRepository;
        private readonly IMapper _mapper;

        public GetListProfileExamQueryHandler(IProfileExamRepository profileExamRepository, IMapper mapper)
        {
            _profileExamRepository = profileExamRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileExamListItemDto>> Handle(GetListProfileExamQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileExam> profileExams = await _profileExamRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileExamListItemDto> response = _mapper.Map<GetListResponse<GetListProfileExamListItemDto>>(profileExams);
            return response;
        }
    }
}