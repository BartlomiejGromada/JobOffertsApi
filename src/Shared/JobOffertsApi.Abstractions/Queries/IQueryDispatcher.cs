﻿using System.Threading;
using System.Threading.Tasks;

namespace JobOffersApi.Abstractions.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}