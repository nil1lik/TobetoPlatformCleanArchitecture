using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Queries.GetList;

public class GetListLessonVideoDetailVideoDetailCategoryQuery : IRequest<GetListResponse<GetListLessonVideoDetailVideoDetailCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLessonVideoDetailVideoDetailCategoryQueryHandler : IRequestHandler<GetListLessonVideoDetailVideoDetailCategoryQuery, GetListResponse<GetListLessonVideoDetailVideoDetailCategoryListItemDto>>
    {
        private readonly ILessonVideoDetailVideoDetailCategoryRepository _lessonVideoDetailVideoDetailCategoryRepository;
        private readonly IMapper _mapper;

        public GetListLessonVideoDetailVideoDetailCategoryQueryHandler(ILessonVideoDetailVideoDetailCategoryRepository lessonVideoDetailVideoDetailCategoryRepository, IMapper mapper)
        {
            _lessonVideoDetailVideoDetailCategoryRepository = lessonVideoDetailVideoDetailCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonVideoDetailVideoDetailCategoryListItemDto>> Handle(GetListLessonVideoDetailVideoDetailCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LessonVideoDetailVideoDetailCategory> lessonVideoDetailVideoDetailCategories = await _lessonVideoDetailVideoDetailCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonVideoDetailVideoDetailCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListLessonVideoDetailVideoDetailCategoryListItemDto>>(lessonVideoDetailVideoDetailCategories);
            return response;
        }
    }
}