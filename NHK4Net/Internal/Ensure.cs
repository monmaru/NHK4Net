using System;

namespace NHK4Net.Internal
{
    internal static class Ensure
    {
        internal static void ArgumentNotNull(object value)
        {
            if (value != null) return;

            throw new ArgumentNullException(nameof(value));
        }

        internal static void ArgumentNotNullOrEmptyString(string value)
        {
            ArgumentNotNull(value);
            if (!string.IsNullOrWhiteSpace(value)) return;

            throw new ArgumentException("String cannot be empty", nameof(value));
        }
    }
}
