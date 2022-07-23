namespace Interview.Application.Services
{
    public class ResultService
    {
        private const string ErrorMessage = "Error";
        private const string SuccessMessage = "Success";
        public bool IsSuccess { get; set; }
        public string Message { get; private set; } = "Erros ocurred during validation";
        public IReadOnlyCollection<string> Erros { get; set; }

        public static ResultService<T> RequestError<T>(IReadOnlyCollection<string> notifications)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Erros = notifications
            };
        }

        public static ResultService Fail(string message = ErrorMessage) => new ResultService { IsSuccess = false, Message = message };
        public static ResultService<T> Fail<T>(string message = ErrorMessage) => new ResultService<T> { IsSuccess = false, Message = message };

        public static ResultService Ok(string message = SuccessMessage) => new ResultService { IsSuccess = true, Message = message };
        public static ResultService<T> Ok<T>(T data, string message = SuccessMessage) => new ResultService<T> { IsSuccess = true, Message = message, Data = data };
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
