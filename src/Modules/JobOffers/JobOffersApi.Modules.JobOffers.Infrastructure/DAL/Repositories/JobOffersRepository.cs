﻿using Microsoft.EntityFrameworkCore;
using JobOffersApi.Modules.JobOffers.Core.Repositories;
using JobOffersApi.Modules.JobOffers.Core.Entities;

namespace JobOffersApi.Modules.Users.Infrastructure.DAL.Repositories;

internal class JobOffersRepository : IJobOffersRepository
{
    private readonly JobOffersDbContext _context;
    private readonly DbSet<JobOffer> _jobOffers;

    public JobOffersRepository(JobOffersDbContext context)
    {
        _context = context;
        _jobOffers = context.JobOffers;
    }

    public Task<JobOffer?> GetAsync(Guid id, CancellationToken cancellationToken = default) 
        => _jobOffers.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    
    public async Task AddAsync(JobOffer jobOffer, CancellationToken cancellationToken = default)
    {
        await _jobOffers.AddAsync(jobOffer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}