using Application.Features.UserApplications.Constants;
using Application.Features.UserApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserApplications.Commands.Delete;

public class DeleteUserApplicationCommand : IRequest<DeletedUserApplicationResponse>
{
    public int Id { get; set; }

    public class DeleteUserApplicationCommandHandler : IRequestHandler<DeleteUserApplicationCommand, DeletedUserApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserApplicationRepository _userApplicationRepository;
        private readonly UserApplicationBusinessRules _userApplicationBusinessRules;

        public DeleteUserApplicationCommandHandler(IMapper mapper, IUserApplicationRepository userApplicationRepository,
                                         UserApplicationBusinessRules userApplicationBusinessRules)
        {
            _mapper = mapper;
            _userApplicationRepository = userApplicationRepository;
            _userApplicationBusinessRules = userApplicationBusinessRules;
        }

        public async Task<DeletedUserApplicationResponse> Handle(DeleteUserApplicationCommand request, CancellationToken cancellationToken)
        {
            UserApplication? userApplication = await _userApplicationRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userApplicationBusinessRules.UserApplicationShouldExistWhenSelected(userApplication);

            await _userApplicationRepository.DeleteAsync(userApplication!);

            DeletedUserApplicationResponse response = _mapper.Map<DeletedUserApplicationResponse>(userApplication);
            return response;
        }
    }
}