using Application.Features.VideoDetailSubcategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoDetailSubcategories.Queries.GetById;

public class GetByIdVideoDetailSubcategoryQuery : IRequest<GetByIdVideoDetailSubcategoryResponse>
{
    public int Id { get; set; }

    public class GetByIdVideoDetailSubcategoryQueryHandler : IRequestHandler<GetByIdVideoDetailSubcategoryQuery, GetByIdVideoDetailSubcategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoDetailSubcategoryRepository _videoDetailSubcategoryRepository;
        private readonly VideoDetailSubcategoryBusinessRules _videoDetailSubcategoryBusinessRules;

        public GetByIdVideoDetailSubcategoryQueryHandler(IMapper mapper, IVideoDetailSubcategoryRepository videoDetailSubcategoryRepository, VideoDetailSubcategoryBusinessRules videoDetailSubcategoryBusinessRules)
        {
            _mapper = mapper;
            _videoDetailSubcategoryRepository = videoDetailSubcategoryRepository;
            _videoDetailSubcategoryBusinessRules = videoDetailSubcategoryBusinessRules;
        }

        public async Task<GetByIdVideoDetailSubcategoryResponse> Handle(GetByIdVideoDetailSubcategoryQuery request, CancellationToken cancellationToken)
        {
            VideoDetailSubcategory? videoDetailSubcategory = await _videoDetailSubcategoryRepository.GetAsync(predicate: vds => vds.Id == request.Id, cancellationToken: cancellationToken);
            await _videoDetailSubcategoryBusinessRules.VideoDetailSubcategoryShouldExistWhenSelected(videoDetailSubcategory);

            GetByIdVideoDetailSubcategoryResponse response = _mapper.Map<GetByIdVideoDetailSubcategoryResponse>(videoDetailSubcategory);
            return response;
        }
    }
}