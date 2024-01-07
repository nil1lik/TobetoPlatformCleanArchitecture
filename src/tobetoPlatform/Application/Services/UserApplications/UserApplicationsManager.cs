using Application.Features.UserApplications.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserApplications;

public class UserApplicationsManager : IUserApplicationsService
{
    private readonly IUserApplicationRepository _userApplicationRepository;
    private readonly UserApplicationBusinessRules _userApplicationBusinessRules;

    public UserApplicationsManager(IUserApplicationRepository userApplicationRepository, UserApplicationBusinessRules userApplicationBusinessRules)
    {
        _userApplicationRepository = userApplicationRepository;
        _userApplicationBusinessRules = userApplicationBusinessRules;
    }

    public async Task<UserApplication?> GetAsync(
        Expression<Func<UserApplication, bool>> predicate,
        Func<IQueryable<UserApplication>, IIncludableQueryable<UserApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserApplication? userApplication = await _userApplicationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userApplication;
    }

    public async Task<IPaginate<UserApplication>?> GetListAsync(
        Expression<Func<UserApplication, bool>>? predicate = null,
        Func<IQueryable<UserApplication>, IOrderedQueryable<UserApplication>>? orderBy = null,
        Func<IQueryable<UserApplication>, IIncludableQueryable<UserApplication, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserApplication> userApplicationList = await _userApplicationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userApplicationList;
    }

    public async Task<UserApplication> AddAsync(UserApplication userApplication)
    {
        UserApplication addedUserApplication = await _userApplicationRepository.AddAsync(userApplication);

        return addedUserApplication;
    }

    public async Task<UserApplication> UpdateAsync(UserApplication userApplication)
    {
        UserApplication updatedUserApplication = await _userApplicationRepository.UpdateAsync(userApplication);

        return updatedUserApplication;
    }

    public async Task<UserApplication> DeleteAsync(UserApplication userApplication, bool permanent = false)
    {
        UserApplication deletedUserApplication = await _userApplicationRepository.DeleteAsync(userApplication);

        return deletedUserApplication;
    }
}
