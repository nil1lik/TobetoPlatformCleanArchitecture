using Application.Features.ProfileShares.Commands.Create;
using Application.Features.ProfileShares.Commands.Delete;
using Application.Features.ProfileShares.Commands.Update;
using Application.Features.ProfileShares.Queries.GetById;
using Application.Features.ProfileShares.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileSharesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileShareCommand createProfileShareCommand)
    {
        CreatedProfileShareResponse response = await Mediator.Send(createProfileShareCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileShareCommand updateProfileShareCommand)
    {
        UpdatedProfileShareResponse response = await Mediator.Send(updateProfileShareCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileShareResponse response = await Mediator.Send(new DeleteProfileShareCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileShareResponse response = await Mediator.Send(new GetByIdProfileShareQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileShareQuery getListProfileShareQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileShareListItemDto> response = await Mediator.Send(getListProfileShareQuery);
        return Ok(response);
    }
}