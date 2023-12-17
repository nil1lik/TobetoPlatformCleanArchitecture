using Application.Features.Graduations.Constants;
using Application.Features.Graduations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Graduations.Commands.Delete;

public class DeleteGraduationCommand : IRequest<DeletedGraduationResponse>
{
    public int Id { get; set; }

    public class DeleteGraduationCommandHandler : IRequestHandler<DeleteGraduationCommand, DeletedGraduationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationRepository _graduationRepository;
        private readonly GraduationBusinessRules _graduationBusinessRules;

        public DeleteGraduationCommandHandler(IMapper mapper, IGraduationRepository graduationRepository,
                                         GraduationBusinessRules graduationBusinessRules)
        {
            _mapper = mapper;
            _graduationRepository = graduationRepository;
            _graduationBusinessRules = graduationBusinessRules;
        }

        public async Task<DeletedGraduationResponse> Handle(DeleteGraduationCommand request, CancellationToken cancellationToken)
        {
            Graduation? graduation = await _graduationRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationBusinessRules.GraduationShouldExistWhenSelected(graduation);

            await _graduationRepository.DeleteAsync(graduation!);

            DeletedGraduationResponse response = _mapper.Map<DeletedGraduationResponse>(graduation);
            return response;
        }
    }
}