﻿using System.Threading.Tasks;

namespace NHK4Net.Internal
{
    internal static class TaskExtensions
    {
        internal static async Task<T> ContextFree<T>(this Task<T> task) => await task.ConfigureAwait(false);
    }
}
