using Application.Features.VideoDetailSubcategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoDetailSubcategories.Commands.Update;

public class UpdateVideoDetailSubcategoryCommand : IRequest<UpdatedVideoDetailSubcategoryResponse>
{
    public int Id { get; set; }
    public int VideoDetailCategoryId { get; set; }
    public string Name { get; set; }

    public class UpdateVideoDetailSubcategoryCommandHandler : IRequestHandler<UpdateVideoDetailSubcategoryCommand, UpdatedVideoDetailSubcategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoDetailSubcategoryRepository _videoDetailSubcategoryRepository;
        private readonly VideoDetailSubcategoryBusinessRules _videoDetailSubcategoryBusinessRules;

        public UpdateVideoDetailSubcategoryCommandHandler(IMapper mapper, IVideoDetailSubcategoryRepository videoDetailSubcategoryRepository,
                                         VideoDetailSubcategoryBusinessRules videoDetailSubcategoryBusinessRules)
        {
            _mapper = mapper;
            _videoDetailSubcategoryRepository = videoDetailSubcategoryRepository;
            _videoDetailSubcategoryBusinessRules = videoDetailSubcategoryBusinessRules;
        }

        public async Task<UpdatedVideoDetailSubcategoryResponse> Handle(UpdateVideoDetailSubcategoryCommand request, CancellationToken cancellationToken)
        {
            VideoDetailSubcategory? videoDetailSubcategory = await _videoDetailSubcategoryRepository.GetAsync(predicate: vds => vds.Id == request.Id, cancellationToken: cancellationToken);
            await _videoDetailSubcategoryBusinessRules.VideoDetailSubcategoryShouldExistWhenSelected(videoDetailSubcategory);
            videoDetailSubcategory = _mapper.Map(request, videoDetailSubcategory);

            await _videoDetailSubcategoryRepository.UpdateAsync(videoDetailSubcategory!);

            UpdatedVideoDetailSubcategoryResponse response = _mapper.Map<UpdatedVideoDetailSubcategoryResponse>(videoDetailSubcategory);
            return response;
        }
    }
}