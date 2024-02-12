using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileSkills.Queries.GetList;

public class GetListProfileSkillQuery : IRequest<GetListResponse<GetListProfileSkillListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileSkillQueryHandler : IRequestHandler<GetListProfileSkillQuery, GetListResponse<GetListProfileSkillListItemDto>>
    {
        private readonly IProfileSkillRepository _profileSkillRepository;
        private readonly IMapper _mapper;

        public GetListProfileSkillQueryHandler(IProfileSkillRepository profileSkillRepository, IMapper mapper)
        {
            _profileSkillRepository = profileSkillRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileSkillListItemDto>> Handle(GetListProfileSkillQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileSkill> profileSkills = await _profileSkillRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileSkillListItemDto> response = _mapper.Map<GetListResponse<GetListProfileSkillListItemDto>>(profileSkills);
            return response;
        }
    }
}