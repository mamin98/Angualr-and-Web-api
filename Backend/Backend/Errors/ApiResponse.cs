namespace Backend.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode= statusCode;
            Message= message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, You have made",
                401 => "Authorized, You 're not",
                404 => "Response found it's not",
                500 => "Server error occured",

                // if not happen any thing 
               _ => null
            };
        }
    }
}
