using Application.Features.LessonVideoDetails.Constants;
using Application.Features.LessonVideoDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonVideoDetails.Commands.Delete;

public class DeleteLessonVideoDetailCommand : IRequest<DeletedLessonVideoDetailResponse>
{
    public int Id { get; set; }

    public class DeleteLessonVideoDetailCommandHandler : IRequestHandler<DeleteLessonVideoDetailCommand, DeletedLessonVideoDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoDetailRepository _lessonVideoDetailRepository;
        private readonly LessonVideoDetailBusinessRules _lessonVideoDetailBusinessRules;

        public DeleteLessonVideoDetailCommandHandler(IMapper mapper, ILessonVideoDetailRepository lessonVideoDetailRepository,
                                         LessonVideoDetailBusinessRules lessonVideoDetailBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoDetailRepository = lessonVideoDetailRepository;
            _lessonVideoDetailBusinessRules = lessonVideoDetailBusinessRules;
        }

        public async Task<DeletedLessonVideoDetailResponse> Handle(DeleteLessonVideoDetailCommand request, CancellationToken cancellationToken)
        {
            LessonVideoDetail? lessonVideoDetail = await _lessonVideoDetailRepository.GetAsync(predicate: lvd => lvd.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonVideoDetailBusinessRules.LessonVideoDetailShouldExistWhenSelected(lessonVideoDetail);

            await _lessonVideoDetailRepository.DeleteAsync(lessonVideoDetail!);

            DeletedLessonVideoDetailResponse response = _mapper.Map<DeletedLessonVideoDetailResponse>(lessonVideoDetail);
            return response;
        }
    }
}