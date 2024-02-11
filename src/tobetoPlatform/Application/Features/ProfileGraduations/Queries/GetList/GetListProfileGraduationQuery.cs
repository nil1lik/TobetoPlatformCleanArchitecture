using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileGraduations.Queries.GetList;

public class GetListProfileGraduationQuery : IRequest<GetListResponse<GetListProfileGraduationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileGraduationQueryHandler : IRequestHandler<GetListProfileGraduationQuery, GetListResponse<GetListProfileGraduationListItemDto>>
    {
        private readonly IProfileGraduationRepository _profileGraduationRepository;
        private readonly IMapper _mapper;

        public GetListProfileGraduationQueryHandler(IProfileGraduationRepository profileGraduationRepository, IMapper mapper)
        {
            _profileGraduationRepository = profileGraduationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileGraduationListItemDto>> Handle(GetListProfileGraduationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileGraduation> profileGraduations = await _profileGraduationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileGraduationListItemDto> response = _mapper.Map<GetListResponse<GetListProfileGraduationListItemDto>>(profileGraduations);
            return response;
        }
    }
}