namespace NHK4Net.Internal
{
    internal class NHKError
    {
        public Error Error { get; set; }
    }

    internal class Error
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
    }
}