using Application.Features.EducationAbouts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationAbouts;

public class EducationAboutsManager : IEducationAboutsService
{
    private readonly IEducationAboutRepository _educationAboutRepository;
    private readonly EducationAboutBusinessRules _educationAboutBusinessRules;

    public EducationAboutsManager(IEducationAboutRepository educationAboutRepository, EducationAboutBusinessRules educationAboutBusinessRules)
    {
        _educationAboutRepository = educationAboutRepository;
        _educationAboutBusinessRules = educationAboutBusinessRules;
    }

    public async Task<EducationAbout?> GetAsync(
        Expression<Func<EducationAbout, bool>> predicate,
        Func<IQueryable<EducationAbout>, IIncludableQueryable<EducationAbout, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EducationAbout? educationAbout = await _educationAboutRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return educationAbout;
    }

    public async Task<IPaginate<EducationAbout>?> GetListAsync(
        Expression<Func<EducationAbout, bool>>? predicate = null,
        Func<IQueryable<EducationAbout>, IOrderedQueryable<EducationAbout>>? orderBy = null,
        Func<IQueryable<EducationAbout>, IIncludableQueryable<EducationAbout, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EducationAbout> educationAboutList = await _educationAboutRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return educationAboutList;
    }

    public async Task<EducationAbout> AddAsync(EducationAbout educationAbout)
    {
        EducationAbout addedEducationAbout = await _educationAboutRepository.AddAsync(educationAbout);

        return addedEducationAbout;
    }

    public async Task<EducationAbout> UpdateAsync(EducationAbout educationAbout)
    {
        EducationAbout updatedEducationAbout = await _educationAboutRepository.UpdateAsync(educationAbout);

        return updatedEducationAbout;
    }

    public async Task<EducationAbout> DeleteAsync(EducationAbout educationAbout, bool permanent = false)
    {
        EducationAbout deletedEducationAbout = await _educationAboutRepository.DeleteAsync(educationAbout);

        return deletedEducationAbout;
    }
}
