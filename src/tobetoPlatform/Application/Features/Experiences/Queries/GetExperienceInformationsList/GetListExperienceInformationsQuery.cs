using Amazon.Runtime.Internal;
using Application.Features.Languages.Queries.GetList;
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

namespace Application.Features.Experiences.Queries.GetExperienceInformationsList;
public class GetListExperienceInformationsQuery:IRequest<GetListResponse<GetListExperienceInformationsListDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListExperienceInformationsQueryHandler : IRequestHandler<GetListExperienceInformationsQuery, GetListResponse<GetListExperienceInformationsListDto>>
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public GetListExperienceInformationsQueryHandler(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListExperienceInformationsListDto>> Handle(GetListExperienceInformationsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Experience> experiences = await _experienceRepository.GetListAsync(
                include: l => l.Include(x => x.City),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListExperienceInformationsListDto> response = _mapper.Map<GetListResponse<GetListExperienceInformationsListDto>>(experiences);
            return response;
        }
    }
}
