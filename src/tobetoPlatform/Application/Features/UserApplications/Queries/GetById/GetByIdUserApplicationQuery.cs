using Application.Features.UserApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserApplications.Queries.GetById;

public class GetByIdUserApplicationQuery : IRequest<GetByIdUserApplicationResponse>
{
    public int Id { get; set; }

    public class GetByIdUserApplicationQueryHandler : IRequestHandler<GetByIdUserApplicationQuery, GetByIdUserApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserApplicationRepository _userApplicationRepository;
        private readonly IApplicationStepRepository _applicationStepRepository;
        private readonly UserApplicationBusinessRules _userApplicationBusinessRules;

        public GetByIdUserApplicationQueryHandler(IMapper mapper, IUserApplicationRepository userApplicationRepository, IApplicationStepRepository applicationStepRepository, UserApplicationBusinessRules userApplicationBusinessRules)
        {
            _mapper = mapper;
            _userApplicationRepository = userApplicationRepository;
            _applicationStepRepository = applicationStepRepository;
            _userApplicationBusinessRules = userApplicationBusinessRules;
        }

        public async Task<GetByIdUserApplicationResponse> Handle(GetByIdUserApplicationQuery request, CancellationToken cancellationToken)
        {
            
            UserApplication? userApplication = await _userApplicationRepository.GetAsync(
                predicate: ua => ua.Id == request.Id,
                cancellationToken: cancellationToken);

            await _userApplicationBusinessRules.UserApplicationShouldExistWhenSelected(userApplication);

            GetByIdUserApplicationResponse response = _mapper.Map<GetByIdUserApplicationResponse>(userApplication);
            return response;
        }
    }
}