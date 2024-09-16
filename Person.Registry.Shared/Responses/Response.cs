using System.Net;

namespace Person.Registry.Shared.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string ErroMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public void NotFound(string message)
        {
            StatusCode = HttpStatusCode.NotFound;
            ErroMessage = message;
        }

        public void Success(T data)
        {
            StatusCode = HttpStatusCode.OK;
            Data = data;
        }
    }
}
