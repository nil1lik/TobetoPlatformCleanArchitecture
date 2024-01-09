using Application.Features.Contacts.Constants;
using Application.Features.Contacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Contacts.Commands.Delete;

public class DeleteContactCommand : IRequest<DeletedContactResponse>
{
    public int Id { get; set; }

    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, DeletedContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly ContactBusinessRules _contactBusinessRules;

        public DeleteContactCommandHandler(IMapper mapper, IContactRepository contactRepository,
                                         ContactBusinessRules contactBusinessRules)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _contactBusinessRules = contactBusinessRules;
        }

        public async Task<DeletedContactResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            Contact? contact = await _contactRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contactBusinessRules.ContactShouldExistWhenSelected(contact);

            await _contactRepository.DeleteAsync(contact!);

            DeletedContactResponse response = _mapper.Map<DeletedContactResponse>(contact);
            return response;
        }
    }
}