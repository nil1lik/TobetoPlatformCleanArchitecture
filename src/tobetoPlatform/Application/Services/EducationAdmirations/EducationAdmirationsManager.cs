using Application.Features.EducationAdmirations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationAdmirations;

public class EducationAdmirationsManager : IEducationAdmirationsService
{
    private readonly IEducationAdmirationRepository _educationAdmirationRepository;
    private readonly EducationAdmirationBusinessRules _educationAdmirationBusinessRules;

    public EducationAdmirationsManager(IEducationAdmirationRepository educationAdmirationRepository, EducationAdmirationBusinessRules educationAdmirationBusinessRules)
    {
        _educationAdmirationRepository = educationAdmirationRepository;
        _educationAdmirationBusinessRules = educationAdmirationBusinessRules;
    }

    public async Task<EducationAdmiration?> GetAsync(
        Expression<Func<EducationAdmiration, bool>> predicate,
        Func<IQueryable<EducationAdmiration>, IIncludableQueryable<EducationAdmiration, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EducationAdmiration? educationAdmiration = await _educationAdmirationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return educationAdmiration;
    }

    public async Task<IPaginate<EducationAdmiration>?> GetListAsync(
        Expression<Func<EducationAdmiration, bool>>? predicate = null,
        Func<IQueryable<EducationAdmiration>, IOrderedQueryable<EducationAdmiration>>? orderBy = null,
        Func<IQueryable<EducationAdmiration>, IIncludableQueryable<EducationAdmiration, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EducationAdmiration> educationAdmirationList = await _educationAdmirationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return educationAdmirationList;
    }

    public async Task<EducationAdmiration> AddAsync(EducationAdmiration educationAdmiration)
    {
        EducationAdmiration addedEducationAdmiration = await _educationAdmirationRepository.AddAsync(educationAdmiration);

        return addedEducationAdmiration;
    }

    public async Task<EducationAdmiration> UpdateAsync(EducationAdmiration educationAdmiration)
    {
        EducationAdmiration updatedEducationAdmiration = await _educationAdmirationRepository.UpdateAsync(educationAdmiration);

        return updatedEducationAdmiration;
    }

    public async Task<EducationAdmiration> DeleteAsync(EducationAdmiration educationAdmiration, bool permanent = false)
    {
        EducationAdmiration deletedEducationAdmiration = await _educationAdmirationRepository.DeleteAsync(educationAdmiration);

        return deletedEducationAdmiration;
    }
}
