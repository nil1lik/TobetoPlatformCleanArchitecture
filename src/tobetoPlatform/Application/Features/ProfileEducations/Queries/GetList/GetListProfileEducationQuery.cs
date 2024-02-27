using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileEducations.Queries.GetList;

public class GetListProfileEducationQuery : IRequest<GetListResponse<GetListProfileEducationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileEducationQueryHandler : IRequestHandler<GetListProfileEducationQuery, GetListResponse<GetListProfileEducationListItemDto>>
    {
        private readonly IProfileEducationRepository _profileEducationRepository;
        private readonly IMapper _mapper;
        
        public GetListProfileEducationQueryHandler(IProfileEducationRepository profileEducationRepository, IMapper mapper)
        {
            _profileEducationRepository = profileEducationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileEducationListItemDto>> Handle(GetListProfileEducationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileEducation> profileEducations = await _profileEducationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileEducationListItemDto> response = _mapper.Map<GetListResponse<GetListProfileEducationListItemDto>>(profileEducations);
            return response;
        }
    }
}