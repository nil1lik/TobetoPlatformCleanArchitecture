using Application.Features.VideoDetailSubcategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoDetailSubcategories.Commands.Create;

public class CreateVideoDetailSubcategoryCommand : IRequest<CreatedVideoDetailSubcategoryResponse>
{
    public int VideoDetailCategoryId { get; set; }
    public string Name { get; set; }

    public class CreateVideoDetailSubcategoryCommandHandler : IRequestHandler<CreateVideoDetailSubcategoryCommand, CreatedVideoDetailSubcategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoDetailSubcategoryRepository _videoDetailSubcategoryRepository;
        private readonly VideoDetailSubcategoryBusinessRules _videoDetailSubcategoryBusinessRules;

        public CreateVideoDetailSubcategoryCommandHandler(IMapper mapper, IVideoDetailSubcategoryRepository videoDetailSubcategoryRepository,
                                         VideoDetailSubcategoryBusinessRules videoDetailSubcategoryBusinessRules)
        {
            _mapper = mapper;
            _videoDetailSubcategoryRepository = videoDetailSubcategoryRepository;
            _videoDetailSubcategoryBusinessRules = videoDetailSubcategoryBusinessRules;
        }

        public async Task<CreatedVideoDetailSubcategoryResponse> Handle(CreateVideoDetailSubcategoryCommand request, CancellationToken cancellationToken)
        {
            VideoDetailSubcategory videoDetailSubcategory = _mapper.Map<VideoDetailSubcategory>(request);

            await _videoDetailSubcategoryRepository.AddAsync(videoDetailSubcategory);

            CreatedVideoDetailSubcategoryResponse response = _mapper.Map<CreatedVideoDetailSubcategoryResponse>(videoDetailSubcategory);
            return response;
        }
    }
}