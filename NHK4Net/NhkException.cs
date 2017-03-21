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
    public class NhkException : Exception
    {
        internal NhkException(ErrorCode errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCode ErrorCode { get; }
    }
}
