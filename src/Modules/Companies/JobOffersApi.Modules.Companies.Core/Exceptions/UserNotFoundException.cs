﻿using JobOffersApi.Abstractions.Exceptions;

namespace JobOffersApi.Modules.Companies.Core.Exceptions;

internal class UserNotFoundException : ModularException
{
    public UserNotFoundException(string email) : base($"User with email: {email} not found.")
    {
    }
    public UserNotFoundException(Guid id) : base($"User with id: {id} not found.")
    {
    }
}
