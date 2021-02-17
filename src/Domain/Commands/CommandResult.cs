namespace Domain.Commands
{
    public class CommandResult
    {
        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Object = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }
    }
}