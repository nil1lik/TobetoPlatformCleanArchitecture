using Application.Features.ProfileAdmirations.Commands.Create;
using Application.Features.ProfileAdmirations.Commands.Delete;
using Application.Features.ProfileAdmirations.Commands.Update;
using Application.Features.ProfileAdmirations.Queries.GetById;
using Application.Features.ProfileAdmirations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileAdmirationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileAdmirationCommand createProfileAdmirationCommand)
    {
        CreatedProfileAdmirationResponse response = await Mediator.Send(createProfileAdmirationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileAdmirationCommand updateProfileAdmirationCommand)
    {
        UpdatedProfileAdmirationResponse response = await Mediator.Send(updateProfileAdmirationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileAdmirationResponse response = await Mediator.Send(new DeleteProfileAdmirationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileAdmirationResponse response = await Mediator.Send(new GetByIdProfileAdmirationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileAdmirationQuery getListProfileAdmirationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileAdmirationListItemDto> response = await Mediator.Send(getListProfileAdmirationQuery);
        return Ok(response);
    }
}