using Amazon.Runtime.Internal;
using Application.Features.UserApplications.Queries.GetById;
using Application.Features.UserApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserApplications.Queries.GetApplicationDetail;
public class GetApplicationDetailQuery : IRequest<GetApplicationDetailResponse>
{
    public int Id { get; set; }

    public class GetApplicationDetailQueryHandler : IRequestHandler<GetApplicationDetailQuery, GetApplicationDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserApplicationRepository _userApplicationRepository;
        private readonly IApplicationStepRepository _applicationStepRepository;
        private readonly UserApplicationBusinessRules _userApplicationBusinessRules;

        public async Task<GetApplicationDetailResponse>Handle(GetApplicationDetailQuery request, CancellationToken cancellationToken)
        {
            UserApplication? userApplication = await _userApplicationRepository.GetAsync(predicate: ua => ua.Id == request.Id,
                                                                                         include: p => p.Include(p => p.ApplicationSteps),
                                                                                         cancellationToken: cancellationToken);

            await _userApplicationBusinessRules.UserApplicationShouldExistWhenSelected(userApplication);

            GetApplicationDetailResponse response = _mapper.Map<GetApplicationDetailResponse>(userApplication);
            return response;
        }
    }
}
