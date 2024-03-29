﻿namespace Particular.AzureTable.Export
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Microsoft.Azure.Cosmos.Table;

    static class CloudTableExtensions
    {
        public static async IAsyncEnumerable<T> ExecuteQueryAsync<T>(this CloudTable table, TableQuery<T> query, int take = int.MaxValue, [EnumeratorCancellation] CancellationToken cancellationToken = default) where T : ITableEntity, new()
        {
            TableContinuationToken token = null;
            var alreadyTaken = 0;

            do
            {
                var seg = await table.ExecuteQuerySegmentedAsync(
                        query: query,
                        token: token,
                        requestOptions: null,
                        operationContext: null,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                token = seg.ContinuationToken;

                foreach (var entity in seg.Results)
                {
                    if (alreadyTaken < take && !cancellationToken.IsCancellationRequested)
                    {
                        alreadyTaken++;
                        yield return entity;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            while (token != null && !cancellationToken.IsCancellationRequested && alreadyTaken < take);
        }
    }
}