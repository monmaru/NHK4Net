using System;

namespace NHK4Net
{
    public enum ErrorCode
    {
        /// <summary>
        /// This is an error not defined in the NHK番組表API
        /// </summary>
        UnexpectedError, 
        /// <summary>
        /// Invalid parameters
        /// </summary>
        InvalidParameters = 1,
        /// <summary>
        /// Sorry, that page does not exist
        /// </summary>
        NotExist,
        /// <summary>
        /// Rate limit exceeded
        /// </summary>
        RateLimitExceeded,
        /// <summary>
        /// Invalid or expired token
        /// </summary>
        InvalidOrExpiredToken,
        /// <summary>
        /// Over capacity
        /// </summary>
        OverCapacity,
        /// <summary>
        /// Internal error
        /// </summary>
        InternalError
    }

    [Serializable]
    public class NHKException : Exception
    {
        internal NHKException(ErrorCode errorCode, string message)
            : this(errorCode, message, null)
        {
        }

        internal NHKException(ErrorCode errorCode, string message, Exception innerException)
           : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        public ErrorCode ErrorCode { get; }
    }
}
