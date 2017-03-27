using System;

namespace NHK4Net.Internal
{
    internal static class Ensure
    {
        internal static void ArgumentNotNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static void ArgumentNotNullOrEmptyString(string value, string name)
        {
            ArgumentNotNull(value, name);
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("String cannot be empty", name);
            }
        }
    }
}
