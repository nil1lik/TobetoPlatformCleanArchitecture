using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommand : IRequest<CreatedInstructorResponse>
{
    public int CourseInstructorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }

    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, CreatedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public CreateInstructorCommandHandler(IMapper mapper, IInstructorRepository instructorRepository,
                                         InstructorBusinessRules instructorBusinessRules)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<CreatedInstructorResponse> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);

            await _instructorRepository.AddAsync(instructor);

            CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(instructor);
            return response;
        }
    }
}