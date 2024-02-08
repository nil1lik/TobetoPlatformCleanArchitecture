using Application.Features.VideoDetailCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoDetailCategories.Commands.Update;

public class UpdateVideoDetailCategoryCommand : IRequest<UpdatedVideoDetailCategoryResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateVideoDetailCategoryCommandHandler : IRequestHandler<UpdateVideoDetailCategoryCommand, UpdatedVideoDetailCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoDetailCategoryRepository _videoDetailCategoryRepository;
        private readonly VideoDetailCategoryBusinessRules _videoDetailCategoryBusinessRules;

        public UpdateVideoDetailCategoryCommandHandler(IMapper mapper, IVideoDetailCategoryRepository videoDetailCategoryRepository,
                                         VideoDetailCategoryBusinessRules videoDetailCategoryBusinessRules)
        {
            _mapper = mapper;
            _videoDetailCategoryRepository = videoDetailCategoryRepository;
            _videoDetailCategoryBusinessRules = videoDetailCategoryBusinessRules;
        }

        public async Task<UpdatedVideoDetailCategoryResponse> Handle(UpdateVideoDetailCategoryCommand request, CancellationToken cancellationToken)
        {
            VideoDetailCategory? videoDetailCategory = await _videoDetailCategoryRepository.GetAsync(predicate: vdc => vdc.Id == request.Id, cancellationToken: cancellationToken);
            await _videoDetailCategoryBusinessRules.VideoDetailCategoryShouldExistWhenSelected(videoDetailCategory);
            videoDetailCategory = _mapper.Map(request, videoDetailCategory);

            await _videoDetailCategoryRepository.UpdateAsync(videoDetailCategory!);

            UpdatedVideoDetailCategoryResponse response = _mapper.Map<UpdatedVideoDetailCategoryResponse>(videoDetailCategory);
            return response;
        }
    }
}