﻿using System;
using JobOffersApi.Abstractions.Commands;

namespace JobOffersApi.Modules.Users.Core.Commands;

internal record SignUpCommand(
    string Email,
    string Password,
    string RepeatPassword,
    string FirstName,
    string LastName,
    string Role,
    DateTimeOffset DateOfBirth) : ICommand;