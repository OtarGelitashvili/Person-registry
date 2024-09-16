
using MediatR;

namespace Person.Registry.Shared.Handlers
{
    public class BasePageQuery<TResponse> : IRequest<TResponse>
    {
        public int PageSize { get; set; } = 10;
        public string? SearchKey { get; set; }
        public int PageNumber { get; set; } = 1;
    }
}
