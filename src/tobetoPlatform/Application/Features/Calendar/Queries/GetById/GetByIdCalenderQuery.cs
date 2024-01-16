using Amazon.Runtime.Internal;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Calendar.Queries.GetById;
public class GetByIdCalenderQuery : IRequest<GetByIdCalenderResponse>
{
    public int userId { get; set; }

    public class GetByIdCalenderQueryHandler : IRequestHandler<GetByIdCalenderQuery, GetByIdCalenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISyncLessonRepository _syncLessonRepository;
        private readonly IInstructorRepository _instructorRepository;

        public GetByIdCalenderQueryHandler(IMapper mapper, ISyncLessonRepository syncLessonRepository, IInstructorRepository instructorRepository)
        {
            _mapper = mapper;
            _syncLessonRepository = syncLessonRepository;
            _instructorRepository = instructorRepository;
        }

        public async Task<GetByIdCalenderResponse> Handle(GetByIdCalenderQuery request, CancellationToken cancellationToken)
        {
           SyncLesson? syncLesson = await _syncLessonRepository.GetAsync(
               predicate: sl => sl.Id == request.userId,
               include: p => p.Include(x => x.Instructors.Select(i=>i.Id)),
               cancellationToken: cancellationToken);
            GetByIdCalenderResponse response = _mapper.Map<GetByIdCalenderResponse>(syncLesson);
            return response;
        }

    }
}
