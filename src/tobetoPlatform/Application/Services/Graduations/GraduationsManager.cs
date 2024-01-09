using Application.Features.Graduations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Graduations;

public class GraduationsManager : IGraduationsService
{
    private readonly IGraduationRepository _graduationRepository;
    private readonly GraduationBusinessRules _graduationBusinessRules;

    public GraduationsManager(IGraduationRepository graduationRepository, GraduationBusinessRules graduationBusinessRules)
    {
        _graduationRepository = graduationRepository;
        _graduationBusinessRules = graduationBusinessRules;
    }

    public async Task<Graduation?> GetAsync(
        Expression<Func<Graduation, bool>> predicate,
        Func<IQueryable<Graduation>, IIncludableQueryable<Graduation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Graduation? graduation = await _graduationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return graduation;
    }

    public async Task<IPaginate<Graduation>?> GetListAsync(
        Expression<Func<Graduation, bool>>? predicate = null,
        Func<IQueryable<Graduation>, IOrderedQueryable<Graduation>>? orderBy = null,
        Func<IQueryable<Graduation>, IIncludableQueryable<Graduation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Graduation> graduationList = await _graduationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return graduationList;
    }

    public async Task<Graduation> AddAsync(Graduation graduation)
    {
        Graduation addedGraduation = await _graduationRepository.AddAsync(graduation);

        return addedGraduation;
    }

    public async Task<Graduation> UpdateAsync(Graduation graduation)
    {
        Graduation updatedGraduation = await _graduationRepository.UpdateAsync(graduation);

        return updatedGraduation;
    }

    public async Task<Graduation> DeleteAsync(Graduation graduation, bool permanent = false)
    {
        Graduation deletedGraduation = await _graduationRepository.DeleteAsync(graduation);

        return deletedGraduation;
    }
}
