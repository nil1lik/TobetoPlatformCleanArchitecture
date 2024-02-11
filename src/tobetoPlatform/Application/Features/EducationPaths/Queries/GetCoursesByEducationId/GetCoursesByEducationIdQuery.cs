using Amazon.Runtime.Internal;
using Application.Features.EducationPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.EducationPaths.Queries.GetCoursesByEducationId
{
    public class GetCoursesByEducationIdQuery : IRequest<GetCoursesByEducationIdDto>
    {
        public int Id { get; set; }

        public class GetCoursesByEducationIdQueryHandler : IRequestHandler<GetCoursesByEducationIdQuery, GetCoursesByEducationIdDto>
        {
            private readonly IEducationPathRepository _educationPathRepository;
            private readonly IMapper _mapper;
            private readonly EducationPathBusinessRules _educationPathBusinessRules;

            public GetCoursesByEducationIdQueryHandler(IEducationPathRepository educationPathRepository, IMapper mapper, EducationPathBusinessRules educationPathBusinessRules)
            {
                _educationPathRepository = educationPathRepository;
                _mapper = mapper;
                _educationPathBusinessRules = educationPathBusinessRules;
            }

            public async Task<GetCoursesByEducationIdDto> Handle(GetCoursesByEducationIdQuery request, CancellationToken cancellationToken)
            {
                EducationPath? educationPath = await _educationPathRepository.GetAsync(predicate: e => e.Id == request.Id,
                    include: e => e.Include(e => e.Courses),
                    cancellationToken: cancellationToken);
                await _educationPathBusinessRules.EducationPathShouldExistWhenSelected(educationPath);
                GetCoursesByEducationIdDto response = _mapper.Map<GetCoursesByEducationIdDto>(educationPath);
                return response;
            }
        }
    }
}


