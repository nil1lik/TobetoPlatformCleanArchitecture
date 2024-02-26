using Application.Features.LessonVideoDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonVideoDetails.Commands.Create;

public class CreateLessonVideoDetailCommand : IRequest<CreatedLessonVideoDetailResponse>
{
    public int VideoLanguageId { get; set; }
    public int? CompanyId { get; set; }

    public class CreateLessonVideoDetailCommandHandler : IRequestHandler<CreateLessonVideoDetailCommand, CreatedLessonVideoDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoDetailRepository _lessonVideoDetailRepository;
        private readonly LessonVideoDetailBusinessRules _lessonVideoDetailBusinessRules;

        public CreateLessonVideoDetailCommandHandler(IMapper mapper, ILessonVideoDetailRepository lessonVideoDetailRepository,
                                         LessonVideoDetailBusinessRules lessonVideoDetailBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoDetailRepository = lessonVideoDetailRepository;
            _lessonVideoDetailBusinessRules = lessonVideoDetailBusinessRules;
        }

        public async Task<CreatedLessonVideoDetailResponse> Handle(CreateLessonVideoDetailCommand request, CancellationToken cancellationToken)
        {
            LessonVideoDetail lessonVideoDetail = _mapper.Map<LessonVideoDetail>(request);

            await _lessonVideoDetailRepository.AddAsync(lessonVideoDetail);

            CreatedLessonVideoDetailResponse response = _mapper.Map<CreatedLessonVideoDetailResponse>(lessonVideoDetail);
            return response;
        }
    }
}