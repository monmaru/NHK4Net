using System;

namespace NHK4Net
{
    public enum ErrorCode
    {
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
