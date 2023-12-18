using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Graduations.Queries.GetList;

public class GetListGraduationQuery : IRequest<GetListResponse<GetListGraduationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListGraduationQueryHandler : IRequestHandler<GetListGraduationQuery, GetListResponse<GetListGraduationListItemDto>>
    {
        private readonly IGraduationRepository _graduationRepository;
        private readonly IMapper _mapper;

        public GetListGraduationQueryHandler(IGraduationRepository graduationRepository, IMapper mapper)
        {
            _graduationRepository = graduationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGraduationListItemDto>> Handle(GetListGraduationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Graduation> graduations = await _graduationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGraduationListItemDto> response = _mapper.Map<GetListResponse<GetListGraduationListItemDto>>(graduations);
            return response;
        }
    }
}