﻿using JobOffersApi.Abstractions.Queries;
using JobOffersApi.Infrastructure.MsSqlServer;
using JobOffersApi.Modules.Users.Core.DTO;
using JobOffersApi.Modules.Users.Core.Entities;
using JobOffersApi.Modules.Users.Core.Queries;
using JobOffersApi.Modules.Users.Core.Queries.Handlers;
using JobOffersApi.Modules.Users.Core.Storages;
using JobOffersApi.Modules.Users.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace JobOffersApi.Modules.Users.Infrastructure.Storages;

internal sealed class UsersStorage : IUsersStorage
{
    private readonly IQueryable<User> _users;

    public UsersStorage(UsersDbContext dbContext)
    {
        _users = dbContext.Set<User>().AsNoTracking();
    }

    public async Task<UserDetailsDto?> GetDetailsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _users
            .SingleOrDefaultAsync(x => x.Id == userId, cancellationToken);

        return user?.AsDetailsDto();
    }

    public async Task<Paged<UserDto>> GetPagedAsync(BrowseUsers query, CancellationToken cancellationToken = default)
    {
        var users = _users;

        if (!string.IsNullOrWhiteSpace(query.Email))
        {
            users = users.Where(x => x.Email == query.Email);
        }

        if (!string.IsNullOrWhiteSpace(query.Role))
        {
            users = users.Where(x => x.RoleId == query.Role);
        }

        return await users
            .OrderByDescending(keySelector: x => x.CreatedAt)
            .Select(x => x.AsDto())
            .PaginateAsync(query, cancellationToken);
    }

    public async Task<UserDto?> GetAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _users
            .SingleOrDefaultAsync(x => x.Id == userId, cancellationToken);

        return user?.AsDto();
    }
}