using Application.Features.VideoDetailCategories.Constants;
using Application.Features.VideoDetailCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoDetailCategories.Commands.Delete;

public class DeleteVideoDetailCategoryCommand : IRequest<DeletedVideoDetailCategoryResponse>
{
    public int Id { get; set; }

    public class DeleteVideoDetailCategoryCommandHandler : IRequestHandler<DeleteVideoDetailCategoryCommand, DeletedVideoDetailCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoDetailCategoryRepository _videoDetailCategoryRepository;
        private readonly VideoDetailCategoryBusinessRules _videoDetailCategoryBusinessRules;

        public DeleteVideoDetailCategoryCommandHandler(IMapper mapper, IVideoDetailCategoryRepository videoDetailCategoryRepository,
                                         VideoDetailCategoryBusinessRules videoDetailCategoryBusinessRules)
        {
            _mapper = mapper;
            _videoDetailCategoryRepository = videoDetailCategoryRepository;
            _videoDetailCategoryBusinessRules = videoDetailCategoryBusinessRules;
        }

        public async Task<DeletedVideoDetailCategoryResponse> Handle(DeleteVideoDetailCategoryCommand request, CancellationToken cancellationToken)
        {
            VideoDetailCategory? videoDetailCategory = await _videoDetailCategoryRepository.GetAsync(predicate: vdc => vdc.Id == request.Id, cancellationToken: cancellationToken);
            await _videoDetailCategoryBusinessRules.VideoDetailCategoryShouldExistWhenSelected(videoDetailCategory);

            await _videoDetailCategoryRepository.DeleteAsync(videoDetailCategory!);

            DeletedVideoDetailCategoryResponse response = _mapper.Map<DeletedVideoDetailCategoryResponse>(videoDetailCategory);
            return response;
        }
    }
}