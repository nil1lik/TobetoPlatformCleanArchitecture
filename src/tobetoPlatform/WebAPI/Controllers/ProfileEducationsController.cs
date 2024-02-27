using Application.Features.ProfileEducations.Commands.Create;
using Application.Features.ProfileEducations.Commands.Delete;
using Application.Features.ProfileEducations.Commands.Update;
using Application.Features.ProfileEducations.Queries.GetById;
using Application.Features.ProfileEducations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileEducationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileEducationCommand createProfileEducationCommand)
    {
        CreatedProfileEducationResponse response = await Mediator.Send(createProfileEducationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileEducationCommand updateProfileEducationCommand)
    {
        UpdatedProfileEducationResponse response = await Mediator.Send(updateProfileEducationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileEducationResponse response = await Mediator.Send(new DeleteProfileEducationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileEducationResponse response = await Mediator.Send(new GetByIdProfileEducationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileEducationQuery getListProfileEducationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileEducationListItemDto> response = await Mediator.Send(getListProfileEducationQuery);
        return Ok(response);
    }
}