namespace NHK4Net.Internal
{
    public class NHKError
    {
        public Error Error { get; set; }
    }

    public class Error
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
    }
}