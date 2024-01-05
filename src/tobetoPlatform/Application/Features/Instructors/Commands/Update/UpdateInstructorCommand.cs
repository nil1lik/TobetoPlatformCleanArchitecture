using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorCommand : IRequest<UpdatedInstructorResponse>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }

    public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, UpdatedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public UpdateInstructorCommandHandler(IMapper mapper, IInstructorRepository instructorRepository,
                                         InstructorBusinessRules instructorBusinessRules)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<UpdatedInstructorResponse> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);
            instructor = _mapper.Map(request, instructor);

            await _instructorRepository.UpdateAsync(instructor!);

            UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(instructor);
            return response;
        }
    }
}