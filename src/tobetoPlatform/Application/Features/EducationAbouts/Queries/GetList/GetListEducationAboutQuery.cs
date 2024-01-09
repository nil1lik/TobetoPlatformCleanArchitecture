using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.EducationAbouts.Queries.GetList;

public class GetListEducationAboutQuery : IRequest<GetListResponse<GetListEducationAboutListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListEducationAboutQueryHandler : IRequestHandler<GetListEducationAboutQuery, GetListResponse<GetListEducationAboutListItemDto>>
    {
        private readonly IEducationAboutRepository _educationAboutRepository;
        private readonly IMapper _mapper;

        public GetListEducationAboutQueryHandler(IEducationAboutRepository educationAboutRepository, IMapper mapper)
        {
            _educationAboutRepository = educationAboutRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEducationAboutListItemDto>> Handle(GetListEducationAboutQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EducationAbout> educationAbouts = await _educationAboutRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEducationAboutListItemDto> response = _mapper.Map<GetListResponse<GetListEducationAboutListItemDto>>(educationAbouts);
            return response;
        }
    }
}