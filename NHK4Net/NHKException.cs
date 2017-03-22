using System;

namespace NHK4Net
{
    public enum ErrorCode
    {
        Other, // This is an error not defined in the NHK番組表API.
        InvalidParameters = 1,
        NotExist,
        RateLimitExceeded,
        InvalidOrExpiredToken,
        OverCapacity,
        InternalError
    }

    [Serializable]
    public class NHKException : Exception
    {
        internal NHKException(ErrorCode errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCode ErrorCode { get; }
    }
}
