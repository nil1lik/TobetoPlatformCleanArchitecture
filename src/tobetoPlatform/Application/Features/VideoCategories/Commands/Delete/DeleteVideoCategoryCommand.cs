using Application.Features.VideoCategories.Constants;
using Application.Features.VideoCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoCategories.Commands.Delete;

public class DeleteVideoCategoryCommand : IRequest<DeletedVideoCategoryResponse>
{
    public int Id { get; set; }

    public class DeleteVideoCategoryCommandHandler : IRequestHandler<DeleteVideoCategoryCommand, DeletedVideoCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoCategoryRepository _videoCategoryRepository;
        private readonly VideoCategoryBusinessRules _videoCategoryBusinessRules;

        public DeleteVideoCategoryCommandHandler(IMapper mapper, IVideoCategoryRepository videoCategoryRepository,
                                         VideoCategoryBusinessRules videoCategoryBusinessRules)
        {
            _mapper = mapper;
            _videoCategoryRepository = videoCategoryRepository;
            _videoCategoryBusinessRules = videoCategoryBusinessRules;
        }

        public async Task<DeletedVideoCategoryResponse> Handle(DeleteVideoCategoryCommand request, CancellationToken cancellationToken)
        {
            VideoCategory? videoCategory = await _videoCategoryRepository.GetAsync(predicate: vc => vc.Id == request.Id, cancellationToken: cancellationToken);
            await _videoCategoryBusinessRules.VideoCategoryShouldExistWhenSelected(videoCategory);

            await _videoCategoryRepository.DeleteAsync(videoCategory!);

            DeletedVideoCategoryResponse response = _mapper.Map<DeletedVideoCategoryResponse>(videoCategory);
            return response;
        }
    }
}