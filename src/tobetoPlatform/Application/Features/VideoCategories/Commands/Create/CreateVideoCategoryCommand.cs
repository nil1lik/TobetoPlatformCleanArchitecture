using Application.Features.VideoCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoCategories.Commands.Create;

public class CreateVideoCategoryCommand : IRequest<CreatedVideoCategoryResponse>
{
    public string Name { get; set; }

    public class CreateVideoCategoryCommandHandler : IRequestHandler<CreateVideoCategoryCommand, CreatedVideoCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoCategoryRepository _videoCategoryRepository;
        private readonly VideoCategoryBusinessRules _videoCategoryBusinessRules;

        public CreateVideoCategoryCommandHandler(IMapper mapper, IVideoCategoryRepository videoCategoryRepository,
                                         VideoCategoryBusinessRules videoCategoryBusinessRules)
        {
            _mapper = mapper;
            _videoCategoryRepository = videoCategoryRepository;
            _videoCategoryBusinessRules = videoCategoryBusinessRules;
        }

        public async Task<CreatedVideoCategoryResponse> Handle(CreateVideoCategoryCommand request, CancellationToken cancellationToken)
        {
            VideoCategory videoCategory = _mapper.Map<VideoCategory>(request);

            await _videoCategoryRepository.AddAsync(videoCategory);

            CreatedVideoCategoryResponse response = _mapper.Map<CreatedVideoCategoryResponse>(videoCategory);
            return response;
        }
    }
}