using Application.Features.VideoDetailCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoDetailCategories.Queries.GetById;

public class GetByIdVideoDetailCategoryQuery : IRequest<GetByIdVideoDetailCategoryResponse>
{
    public int Id { get; set; }

    public class GetByIdVideoDetailCategoryQueryHandler : IRequestHandler<GetByIdVideoDetailCategoryQuery, GetByIdVideoDetailCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoDetailCategoryRepository _videoDetailCategoryRepository;
        private readonly VideoDetailCategoryBusinessRules _videoDetailCategoryBusinessRules;

        public GetByIdVideoDetailCategoryQueryHandler(IMapper mapper, IVideoDetailCategoryRepository videoDetailCategoryRepository, VideoDetailCategoryBusinessRules videoDetailCategoryBusinessRules)
        {
            _mapper = mapper;
            _videoDetailCategoryRepository = videoDetailCategoryRepository;
            _videoDetailCategoryBusinessRules = videoDetailCategoryBusinessRules;
        }

        public async Task<GetByIdVideoDetailCategoryResponse> Handle(GetByIdVideoDetailCategoryQuery request, CancellationToken cancellationToken)
        {
            VideoDetailCategory? videoDetailCategory = await _videoDetailCategoryRepository.GetAsync(predicate: vdc => vdc.Id == request.Id, cancellationToken: cancellationToken);
            await _videoDetailCategoryBusinessRules.VideoDetailCategoryShouldExistWhenSelected(videoDetailCategory);

            GetByIdVideoDetailCategoryResponse response = _mapper.Map<GetByIdVideoDetailCategoryResponse>(videoDetailCategory);
            return response;
        }
    }
}