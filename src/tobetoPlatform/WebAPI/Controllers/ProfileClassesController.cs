using Application.Features.ProfileClasses.Commands.Create;
using Application.Features.ProfileClasses.Commands.Delete;
using Application.Features.ProfileClasses.Commands.Update;
using Application.Features.ProfileClasses.Queries.GetById;
using Application.Features.ProfileClasses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileClassesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileClassCommand createProfileClassCommand)
    {
        CreatedProfileClassResponse response = await Mediator.Send(createProfileClassCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileClassCommand updateProfileClassCommand)
    {
        UpdatedProfileClassResponse response = await Mediator.Send(updateProfileClassCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileClassResponse response = await Mediator.Send(new DeleteProfileClassCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileClassResponse response = await Mediator.Send(new GetByIdProfileClassQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileClassQuery getListProfileClassQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileClassListItemDto> response = await Mediator.Send(getListProfileClassQuery);
        return Ok(response);
    }
}