using Application.Features.ProfileApplications.Commands.Create;
using Application.Features.ProfileApplications.Commands.Delete;
using Application.Features.ProfileApplications.Commands.Update;
using Application.Features.ProfileApplications.Queries.GetById;
using Application.Features.ProfileApplications.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileApplicationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileApplicationCommand createProfileApplicationCommand)
    {
        CreatedProfileApplicationResponse response = await Mediator.Send(createProfileApplicationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileApplicationCommand updateProfileApplicationCommand)
    {
        UpdatedProfileApplicationResponse response = await Mediator.Send(updateProfileApplicationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileApplicationResponse response = await Mediator.Send(new DeleteProfileApplicationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileApplicationResponse response = await Mediator.Send(new GetByIdProfileApplicationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileApplicationQuery getListProfileApplicationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileApplicationListItemDto> response = await Mediator.Send(getListProfileApplicationQuery);
        return Ok(response);
    }
}