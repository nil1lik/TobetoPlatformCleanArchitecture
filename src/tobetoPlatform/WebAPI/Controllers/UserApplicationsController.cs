using Application.Features.UserApplications.Commands.Create;
using Application.Features.UserApplications.Commands.Delete;
using Application.Features.UserApplications.Commands.Update;
using Application.Features.UserApplications.Queries.GetById;
using Application.Features.UserApplications.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserApplicationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserApplicationCommand createUserApplicationCommand)
    {
        CreatedUserApplicationResponse response = await Mediator.Send(createUserApplicationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserApplicationCommand updateUserApplicationCommand)
    {
        UpdatedUserApplicationResponse response = await Mediator.Send(updateUserApplicationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedUserApplicationResponse response = await Mediator.Send(new DeleteUserApplicationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdUserApplicationResponse response = await Mediator.Send(new GetByIdUserApplicationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserApplicationQuery getListUserApplicationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserApplicationListItemDto> response = await Mediator.Send(getListUserApplicationQuery);
        return Ok(response);
    }
}