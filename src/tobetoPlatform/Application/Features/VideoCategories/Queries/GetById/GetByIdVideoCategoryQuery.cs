using Application.Features.VideoCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VideoCategories.Queries.GetById;

public class GetByIdVideoCategoryQuery : IRequest<GetByIdVideoCategoryResponse>
{
    public int Id { get; set; }

    public class GetByIdVideoCategoryQueryHandler : IRequestHandler<GetByIdVideoCategoryQuery, GetByIdVideoCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoCategoryRepository _videoCategoryRepository;
        private readonly VideoCategoryBusinessRules _videoCategoryBusinessRules;

        public GetByIdVideoCategoryQueryHandler(IMapper mapper, IVideoCategoryRepository videoCategoryRepository, VideoCategoryBusinessRules videoCategoryBusinessRules)
        {
            _mapper = mapper;
            _videoCategoryRepository = videoCategoryRepository;
            _videoCategoryBusinessRules = videoCategoryBusinessRules;
        }

        public async Task<GetByIdVideoCategoryResponse> Handle(GetByIdVideoCategoryQuery request, CancellationToken cancellationToken)
        {
            VideoCategory? videoCategory = await _videoCategoryRepository.GetAsync(predicate: vc => vc.Id == request.Id, cancellationToken: cancellationToken);
            await _videoCategoryBusinessRules.VideoCategoryShouldExistWhenSelected(videoCategory);

            GetByIdVideoCategoryResponse response = _mapper.Map<GetByIdVideoCategoryResponse>(videoCategory);
            return response;
        }
    }
}