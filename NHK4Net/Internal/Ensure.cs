using System;

namespace NHK4Net.Internal
{
    internal static class Ensure
    {
        public static void ArgumentNotNull(object value)
        {
            if (value != null) return;

            throw new ArgumentNullException(nameof(value));
        }

        public static void ArgumentNotNullOrEmptyString(string value)
        {
            ArgumentNotNull(value);
            if (!string.IsNullOrWhiteSpace(value)) return;

            throw new ArgumentException("String cannot be empty", nameof(value));
        }
    }
}
