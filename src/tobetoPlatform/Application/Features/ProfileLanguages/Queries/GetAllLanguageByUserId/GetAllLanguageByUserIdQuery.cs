using Amazon.Runtime.Internal;
using Application.Features.ProfileLanguages.Queries.GetList;
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

namespace Application.Features.ProfileLanguages.Queries.GetAllLanguageByUserId;
public class GetAllLanguageByUserIdQuery : IRequest<GetListResponse<GetAllLanguageByUserIdResponse>>
{
    public PageRequest PageRequest { get; set; }

    public class GetAllLanguageByUserIdQueryHandler : IRequestHandler<GetAllLanguageByUserIdQuery, GetListResponse<GetAllLanguageByUserIdResponse>>
    {
        private readonly IProfileLanguageRepository _profileLanguageRepository;
        private readonly IMapper _mapper;

        public GetAllLanguageByUserIdQueryHandler(IProfileLanguageRepository profileLanguageRepository, IMapper mapper)
        {
            _profileLanguageRepository = profileLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetAllLanguageByUserIdResponse>> Handle(GetAllLanguageByUserIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileLanguage> profileLanguages = await _profileLanguageRepository.GetListAsync(
                include: x=>x.Include(x=>x.Language).ThenInclude(x=>x.LanguageLevel),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetAllLanguageByUserIdResponse> response = _mapper.Map<GetListResponse<GetAllLanguageByUserIdResponse>>(profileLanguages);
            return response;
        }
    }
}
