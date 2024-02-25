using Amazon.Runtime.Internal;
using Application.Features.ProfileLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProfileLanguages.Commands.Delete.DeleteLanguageByUserId;
public class DeleteLanguageByUserIdCommand : IRequest<DeleteLanguageByUserIdResponse>
{
    public int UserProfileId { get; set; }
    public int LanguageId { get; set; }
    public int LanguageLevelId { get; set; }

    public class DeleteLanguageByUserIdCommandHandler : IRequestHandler<DeleteLanguageByUserIdCommand, DeleteLanguageByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileLanguageRepository _profileLanguageRepository;
        private readonly ProfileLanguageBusinessRules _profileLanguageBusinessRules;

        public DeleteLanguageByUserIdCommandHandler(IMapper mapper, IProfileLanguageRepository profileLanguageRepository,
                                         ProfileLanguageBusinessRules profileLanguageBusinessRules)
        {
            _mapper = mapper;
            _profileLanguageRepository = profileLanguageRepository;
            _profileLanguageBusinessRules = profileLanguageBusinessRules;
        }

        public async Task<DeleteLanguageByUserIdResponse> Handle(DeleteLanguageByUserIdCommand request, CancellationToken cancellationToken)
        {
            ProfileLanguage? profileLanguage = await _profileLanguageRepository.GetAsync(
                predicate: pl => pl.UserProfileId == request.UserProfileId
                              && pl.LanguageId == request.LanguageId
                              && pl.LanguageLevelId == request.LanguageLevelId,
                cancellationToken: cancellationToken);
            await _profileLanguageBusinessRules.ProfileLanguageShouldExistWhenSelected(profileLanguage);

            await _profileLanguageRepository.DeleteAsync(profileLanguage!);

            DeleteLanguageByUserIdResponse response = _mapper.Map<DeleteLanguageByUserIdResponse>(profileLanguage);
            return response;
        }
    }
}
