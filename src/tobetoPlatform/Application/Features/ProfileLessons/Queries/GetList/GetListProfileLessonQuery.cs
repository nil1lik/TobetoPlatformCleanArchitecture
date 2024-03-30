using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileLessons.Queries.GetList;

public class GetListProfileLessonQuery : IRequest<GetListResponse<GetListProfileLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileLessonQueryHandler : IRequestHandler<GetListProfileLessonQuery, GetListResponse<GetListProfileLessonListItemDto>>
    {
        private readonly IProfileLessonRepository _profileLessonRepository;
        private readonly IMapper _mapper;

        public GetListProfileLessonQueryHandler(IProfileLessonRepository profileLessonRepository, IMapper mapper)
        {
            _profileLessonRepository = profileLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileLessonListItemDto>> Handle(GetListProfileLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileLesson> profileLessons = await _profileLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileLessonListItemDto> response = _mapper.Map<GetListResponse<GetListProfileLessonListItemDto>>(profileLessons);
            return response;
        }
    }
}