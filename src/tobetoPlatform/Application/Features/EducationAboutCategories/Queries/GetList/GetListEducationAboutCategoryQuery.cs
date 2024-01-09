using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.EducationAboutCategories.Queries.GetList;

public class GetListEducationAboutCategoryQuery : IRequest<GetListResponse<GetListEducationAboutCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListEducationAboutCategoryQueryHandler : IRequestHandler<GetListEducationAboutCategoryQuery, GetListResponse<GetListEducationAboutCategoryListItemDto>>
    {
        private readonly IEducationAboutCategoryRepository _educationAboutCategoryRepository;
        private readonly IMapper _mapper;

        public GetListEducationAboutCategoryQueryHandler(IEducationAboutCategoryRepository educationAboutCategoryRepository, IMapper mapper)
        {
            _educationAboutCategoryRepository = educationAboutCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEducationAboutCategoryListItemDto>> Handle(GetListEducationAboutCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EducationAboutCategory> educationAboutCategories = await _educationAboutCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEducationAboutCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListEducationAboutCategoryListItemDto>>(educationAboutCategories);
            return response;
        }
    }
}