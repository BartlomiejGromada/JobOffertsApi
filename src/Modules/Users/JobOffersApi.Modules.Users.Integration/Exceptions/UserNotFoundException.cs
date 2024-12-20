﻿using JobOffersApi.Abstractions.Exceptions;

namespace JobOffersApi.Modules.Users.Integration.Exceptions;

public class UserNotFoundException : ModularException
{
    public string Email { get; }
    public Guid UserId { get; }

    public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
    {
        UserId = userId;
    }
    
    public UserNotFoundException(string email) : base($"User with email: '{email}' was not found.")
    {
        Email = email;
    }
}