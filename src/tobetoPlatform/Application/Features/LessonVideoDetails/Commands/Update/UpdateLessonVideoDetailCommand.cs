using Application.Features.LessonVideoDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonVideoDetails.Commands.Update;

public class UpdateLessonVideoDetailCommand : IRequest<UpdatedLessonVideoDetailResponse>
{
    public int Id { get; set; }
    public int VideoLanguageId { get; set; }
    public int? CompanyId { get; set; }

    public class UpdateLessonVideoDetailCommandHandler : IRequestHandler<UpdateLessonVideoDetailCommand, UpdatedLessonVideoDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoDetailRepository _lessonVideoDetailRepository;
        private readonly LessonVideoDetailBusinessRules _lessonVideoDetailBusinessRules;

        public UpdateLessonVideoDetailCommandHandler(IMapper mapper, ILessonVideoDetailRepository lessonVideoDetailRepository,
                                         LessonVideoDetailBusinessRules lessonVideoDetailBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoDetailRepository = lessonVideoDetailRepository;
            _lessonVideoDetailBusinessRules = lessonVideoDetailBusinessRules;
        }

        public async Task<UpdatedLessonVideoDetailResponse> Handle(UpdateLessonVideoDetailCommand request, CancellationToken cancellationToken)
        {
            LessonVideoDetail? lessonVideoDetail = await _lessonVideoDetailRepository.GetAsync(predicate: lvd => lvd.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonVideoDetailBusinessRules.LessonVideoDetailShouldExistWhenSelected(lessonVideoDetail);
            lessonVideoDetail = _mapper.Map(request, lessonVideoDetail);

            await _lessonVideoDetailRepository.UpdateAsync(lessonVideoDetail!);

            UpdatedLessonVideoDetailResponse response = _mapper.Map<UpdatedLessonVideoDetailResponse>(lessonVideoDetail);
            return response;
        }
    }
}