using MediatR;
using Microsoft.AspNetCore.Mvc;
using Person.Registry.Shared.Responses;

namespace Person.Registry.Api.Infrastructure
{
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected async Task<IActionResult> Handle<TResponse>(IRequest<Response<TResponse>> request)
        {
            var response = await _mediator.Send(request);
             
            switch(response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    return NotFound(response);

                default: return Ok(response);
            }
        }
    }
}
