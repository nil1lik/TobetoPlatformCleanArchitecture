using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Skills.Queries.GetList;

public class GetListSkillQuery : IRequest<GetListResponse<GetListSkillListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSkillQueryHandler : IRequestHandler<GetListSkillQuery, GetListResponse<GetListSkillListItemDto>>
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public GetListSkillQueryHandler(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSkillListItemDto>> Handle(GetListSkillQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Skill> skills = await _skillRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSkillListItemDto> response = _mapper.Map<GetListResponse<GetListSkillListItemDto>>(skills);
            return response;
        }
    }
}