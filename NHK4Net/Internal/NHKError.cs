namespace NHK4Net.Internal
{
    internal class RootErrorObject
    {
        public NHKError Error { get; set; }
    }

    internal class NHKError
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
    }
}