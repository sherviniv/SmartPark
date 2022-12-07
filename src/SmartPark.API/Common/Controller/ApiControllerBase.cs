using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartPark.API.Common.Controller;
[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;
}