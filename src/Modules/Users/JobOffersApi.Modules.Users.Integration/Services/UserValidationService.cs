﻿using JobOffersApi.Abstractions.Dispatchers;
using JobOffersApi.Modules.Users.Integration.DTO;
using JobOffersApi.Modules.Users.Integration.Exceptions;
using JobOffersApi.Modules.Users.Integration.Queries;

namespace JobOffersApi.Modules.Users.Integration.Services;

internal class UserValidationService : IUserValidationService
{
    private readonly IDispatcher _dispatcher;

    public UserValidationService(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<UserDto> ValidateAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _dispatcher.QueryAsync(new GetUserQuery { UserId = userId }, cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        if (user.IsLocked)
        {
            throw new UserNotActiveException(userId);
        }

        return user;
    }
}