using Application.Features.ProfileApplicationSteps.Commands.Create;
using Application.Features.ProfileApplicationSteps.Commands.Delete;
using Application.Features.ProfileApplicationSteps.Commands.Update;
using Application.Features.ProfileApplicationSteps.Queries.GetById;
using Application.Features.ProfileApplicationSteps.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileApplicationStepsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileApplicationStepCommand createProfileApplicationStepCommand)
    {
        CreatedProfileApplicationStepResponse response = await Mediator.Send(createProfileApplicationStepCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileApplicationStepCommand updateProfileApplicationStepCommand)
    {
        UpdatedProfileApplicationStepResponse response = await Mediator.Send(updateProfileApplicationStepCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileApplicationStepResponse response = await Mediator.Send(new DeleteProfileApplicationStepCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileApplicationStepResponse response = await Mediator.Send(new GetByIdProfileApplicationStepQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileApplicationStepQuery getListProfileApplicationStepQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileApplicationStepListItemDto> response = await Mediator.Send(getListProfileApplicationStepQuery);
        return Ok(response);
    }
}