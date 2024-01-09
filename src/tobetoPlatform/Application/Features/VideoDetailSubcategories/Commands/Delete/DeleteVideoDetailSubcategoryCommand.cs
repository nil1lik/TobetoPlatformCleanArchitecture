using Application.Features.VideoDetailSubcategories.Constants;
using Application.Features.VideoDetailSubcategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoDetailSubcategories.Commands.Delete;

public class DeleteVideoDetailSubcategoryCommand : IRequest<DeletedVideoDetailSubcategoryResponse>
{
    public int Id { get; set; }

    public class DeleteVideoDetailSubcategoryCommandHandler : IRequestHandler<DeleteVideoDetailSubcategoryCommand, DeletedVideoDetailSubcategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoDetailSubcategoryRepository _videoDetailSubcategoryRepository;
        private readonly VideoDetailSubcategoryBusinessRules _videoDetailSubcategoryBusinessRules;

        public DeleteVideoDetailSubcategoryCommandHandler(IMapper mapper, IVideoDetailSubcategoryRepository videoDetailSubcategoryRepository,
                                         VideoDetailSubcategoryBusinessRules videoDetailSubcategoryBusinessRules)
        {
            _mapper = mapper;
            _videoDetailSubcategoryRepository = videoDetailSubcategoryRepository;
            _videoDetailSubcategoryBusinessRules = videoDetailSubcategoryBusinessRules;
        }

        public async Task<DeletedVideoDetailSubcategoryResponse> Handle(DeleteVideoDetailSubcategoryCommand request, CancellationToken cancellationToken)
        {
            VideoDetailSubcategory? videoDetailSubcategory = await _videoDetailSubcategoryRepository.GetAsync(predicate: vds => vds.Id == request.Id, cancellationToken: cancellationToken);
            await _videoDetailSubcategoryBusinessRules.VideoDetailSubcategoryShouldExistWhenSelected(videoDetailSubcategory);

            await _videoDetailSubcategoryRepository.DeleteAsync(videoDetailSubcategory!);

            DeletedVideoDetailSubcategoryResponse response = _mapper.Map<DeletedVideoDetailSubcategoryResponse>(videoDetailSubcategory);
            return response;
        }
    }
}