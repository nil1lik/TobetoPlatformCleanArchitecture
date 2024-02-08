using Application.Features.VideoDetailCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoDetailCategories.Commands.Create;

public class CreateVideoDetailCategoryCommand : IRequest<CreatedVideoDetailCategoryResponse>
{
    public string Name { get; set; }

    public class CreateVideoDetailCategoryCommandHandler : IRequestHandler<CreateVideoDetailCategoryCommand, CreatedVideoDetailCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoDetailCategoryRepository _videoDetailCategoryRepository;
        private readonly VideoDetailCategoryBusinessRules _videoDetailCategoryBusinessRules;

        public CreateVideoDetailCategoryCommandHandler(IMapper mapper, IVideoDetailCategoryRepository videoDetailCategoryRepository,
                                         VideoDetailCategoryBusinessRules videoDetailCategoryBusinessRules)
        {
            _mapper = mapper;
            _videoDetailCategoryRepository = videoDetailCategoryRepository;
            _videoDetailCategoryBusinessRules = videoDetailCategoryBusinessRules;
        }

        public async Task<CreatedVideoDetailCategoryResponse> Handle(CreateVideoDetailCategoryCommand request, CancellationToken cancellationToken)
        {
            VideoDetailCategory videoDetailCategory = _mapper.Map<VideoDetailCategory>(request);

            await _videoDetailCategoryRepository.AddAsync(videoDetailCategory);

            CreatedVideoDetailCategoryResponse response = _mapper.Map<CreatedVideoDetailCategoryResponse>(videoDetailCategory);
            return response;
        }
    }
}