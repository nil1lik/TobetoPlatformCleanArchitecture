using Application.Features.ProfileExams.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProfileExams;

public class ProfileExamsManager : IProfileExamsService
{
    private readonly IProfileExamRepository _profileExamRepository;
    private readonly ProfileExamBusinessRules _profileExamBusinessRules;

    public ProfileExamsManager(IProfileExamRepository profileExamRepository, ProfileExamBusinessRules profileExamBusinessRules)
    {
        _profileExamRepository = profileExamRepository;
        _profileExamBusinessRules = profileExamBusinessRules;
    }

    public async Task<ProfileExam?> GetAsync(
        Expression<Func<ProfileExam, bool>> predicate,
        Func<IQueryable<ProfileExam>, IIncludableQueryable<ProfileExam, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProfileExam? profileExam = await _profileExamRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return profileExam;
    }

    public async Task<IPaginate<ProfileExam>?> GetListAsync(
        Expression<Func<ProfileExam, bool>>? predicate = null,
        Func<IQueryable<ProfileExam>, IOrderedQueryable<ProfileExam>>? orderBy = null,
        Func<IQueryable<ProfileExam>, IIncludableQueryable<ProfileExam, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProfileExam> profileExamList = await _profileExamRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return profileExamList;
    }

    public async Task<ProfileExam> AddAsync(ProfileExam profileExam)
    {
        ProfileExam addedProfileExam = await _profileExamRepository.AddAsync(profileExam);

        return addedProfileExam;
    }

    public async Task<ProfileExam> UpdateAsync(ProfileExam profileExam)
    {
        ProfileExam updatedProfileExam = await _profileExamRepository.UpdateAsync(profileExam);

        return updatedProfileExam;
    }

    public async Task<ProfileExam> DeleteAsync(ProfileExam profileExam, bool permanent = false)
    {
        ProfileExam deletedProfileExam = await _profileExamRepository.DeleteAsync(profileExam);

        return deletedProfileExam;
    }
}
