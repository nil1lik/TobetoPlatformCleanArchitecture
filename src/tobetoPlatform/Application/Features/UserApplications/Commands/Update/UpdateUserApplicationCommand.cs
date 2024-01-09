using Application.Features.UserApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserApplications.Commands.Update;

public class UpdateUserApplicationCommand : IRequest<UpdatedUserApplicationResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateUserApplicationCommandHandler : IRequestHandler<UpdateUserApplicationCommand, UpdatedUserApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserApplicationRepository _userApplicationRepository;
        private readonly UserApplicationBusinessRules _userApplicationBusinessRules;

        public UpdateUserApplicationCommandHandler(IMapper mapper, IUserApplicationRepository userApplicationRepository,
                                         UserApplicationBusinessRules userApplicationBusinessRules)
        {
            _mapper = mapper;
            _userApplicationRepository = userApplicationRepository;
            _userApplicationBusinessRules = userApplicationBusinessRules;
        }

        public async Task<UpdatedUserApplicationResponse> Handle(UpdateUserApplicationCommand request, CancellationToken cancellationToken)
        {
            UserApplication? userApplication = await _userApplicationRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userApplicationBusinessRules.UserApplicationShouldExistWhenSelected(userApplication);
            userApplication = _mapper.Map(request, userApplication);

            await _userApplicationRepository.UpdateAsync(userApplication!);

            UpdatedUserApplicationResponse response = _mapper.Map<UpdatedUserApplicationResponse>(userApplication);
            return response;
        }
    }
}