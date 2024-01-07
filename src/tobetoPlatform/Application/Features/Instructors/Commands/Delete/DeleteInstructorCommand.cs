using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Instructors.Commands.Delete;

public class DeleteInstructorCommand : IRequest<DeletedInstructorResponse>
{
    public int Id { get; set; }

    public class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand, DeletedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public DeleteInstructorCommandHandler(IMapper mapper, IInstructorRepository instructorRepository,
                                         InstructorBusinessRules instructorBusinessRules)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<DeletedInstructorResponse> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);

            await _instructorRepository.DeleteAsync(instructor!);

            DeletedInstructorResponse response = _mapper.Map<DeletedInstructorResponse>(instructor);
            return response;
        }
    }
}