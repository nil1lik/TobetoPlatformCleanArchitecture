using Application.Features.Classes.Constants;
using Application.Features.Classes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Classes.Commands.Delete;

public class DeleteClassCommand : IRequest<DeletedClassResponse>
{
    public int Id { get; set; }

    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, DeletedClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;
        private readonly ClassBusinessRules _classBusinessRules;

        public DeleteClassCommandHandler(IMapper mapper, IClassRepository classRepository,
                                         ClassBusinessRules classBusinessRules)
        {
            _mapper = mapper;
            _classRepository = classRepository;
            _classBusinessRules = classBusinessRules;
        }

        public async Task<DeletedClassResponse> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            Class? class = await _classRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _classBusinessRules.ClassShouldExistWhenSelected(class);

            await _classRepository.DeleteAsync(class!);

            DeletedClassResponse response = _mapper.Map<DeletedClassResponse>(class);
            return response;
        }
    }
}