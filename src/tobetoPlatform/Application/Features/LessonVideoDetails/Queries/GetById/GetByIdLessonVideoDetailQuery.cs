using Application.Features.LessonVideoDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonVideoDetails.Queries.GetById;

public class GetByIdLessonVideoDetailQuery : IRequest<GetByIdLessonVideoDetailResponse>
{
    public int Id { get; set; }

    public class GetByIdLessonVideoDetailQueryHandler : IRequestHandler<GetByIdLessonVideoDetailQuery, GetByIdLessonVideoDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoDetailRepository _lessonVideoDetailRepository;
        private readonly LessonVideoDetailBusinessRules _lessonVideoDetailBusinessRules;

        public GetByIdLessonVideoDetailQueryHandler(IMapper mapper, ILessonVideoDetailRepository lessonVideoDetailRepository, LessonVideoDetailBusinessRules lessonVideoDetailBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoDetailRepository = lessonVideoDetailRepository;
            _lessonVideoDetailBusinessRules = lessonVideoDetailBusinessRules;
        }

        public async Task<GetByIdLessonVideoDetailResponse> Handle(GetByIdLessonVideoDetailQuery request, CancellationToken cancellationToken)
        {
            LessonVideoDetail? lessonVideoDetail = await _lessonVideoDetailRepository.GetAsync(predicate: lvd => lvd.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonVideoDetailBusinessRules.LessonVideoDetailShouldExistWhenSelected(lessonVideoDetail);

            GetByIdLessonVideoDetailResponse response = _mapper.Map<GetByIdLessonVideoDetailResponse>(lessonVideoDetail);
            return response;
        }
    }
}