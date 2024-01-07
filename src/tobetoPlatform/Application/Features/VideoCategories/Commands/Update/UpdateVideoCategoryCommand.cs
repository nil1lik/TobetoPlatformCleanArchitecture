using Application.Features.VideoCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoCategories.Commands.Update;

public class UpdateVideoCategoryCommand : IRequest<UpdatedVideoCategoryResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateVideoCategoryCommandHandler : IRequestHandler<UpdateVideoCategoryCommand, UpdatedVideoCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoCategoryRepository _videoCategoryRepository;
        private readonly VideoCategoryBusinessRules _videoCategoryBusinessRules;

        public UpdateVideoCategoryCommandHandler(IMapper mapper, IVideoCategoryRepository videoCategoryRepository,
                                         VideoCategoryBusinessRules videoCategoryBusinessRules)
        {
            _mapper = mapper;
            _videoCategoryRepository = videoCategoryRepository;
            _videoCategoryBusinessRules = videoCategoryBusinessRules;
        }

        public async Task<UpdatedVideoCategoryResponse> Handle(UpdateVideoCategoryCommand request, CancellationToken cancellationToken)
        {
            VideoCategory? videoCategory = await _videoCategoryRepository.GetAsync(predicate: vc => vc.Id == request.Id, cancellationToken: cancellationToken);
            await _videoCategoryBusinessRules.VideoCategoryShouldExistWhenSelected(videoCategory);
            videoCategory = _mapper.Map(request, videoCategory);

            await _videoCategoryRepository.UpdateAsync(videoCategory!);

            UpdatedVideoCategoryResponse response = _mapper.Map<UpdatedVideoCategoryResponse>(videoCategory);
            return response;
        }
    }
}