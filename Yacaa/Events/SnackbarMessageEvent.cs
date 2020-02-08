namespace Yacaa.Events
{
    public class SnackbarMessageEvent
    {
        public string Message { get; }

        public SnackbarMessageEvent(string message)
        {
            Message = message;
        }
    }
}