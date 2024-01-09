using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.EducationAdmirations.Queries.GetList;

public class GetListEducationAdmirationQuery : IRequest<GetListResponse<GetListEducationAdmirationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListEducationAdmirationQueryHandler : IRequestHandler<GetListEducationAdmirationQuery, GetListResponse<GetListEducationAdmirationListItemDto>>
    {
        private readonly IEducationAdmirationRepository _educationAdmirationRepository;
        private readonly IMapper _mapper;

        public GetListEducationAdmirationQueryHandler(IEducationAdmirationRepository educationAdmirationRepository, IMapper mapper)
        {
            _educationAdmirationRepository = educationAdmirationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEducationAdmirationListItemDto>> Handle(GetListEducationAdmirationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EducationAdmiration> educationAdmirations = await _educationAdmirationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEducationAdmirationListItemDto> response = _mapper.Map<GetListResponse<GetListEducationAdmirationListItemDto>>(educationAdmirations);
            return response;
        }
    }
}