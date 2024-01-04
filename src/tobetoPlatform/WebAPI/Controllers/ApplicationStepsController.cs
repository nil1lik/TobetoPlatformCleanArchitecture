using Application.Features.ApplicationSteps.Commands.Create;
using Application.Features.ApplicationSteps.Commands.Delete;
using Application.Features.ApplicationSteps.Commands.Update;
using Application.Features.ApplicationSteps.Queries.GetById;
using Application.Features.ApplicationSteps.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationStepsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateApplicationStepCommand createApplicationStepCommand)
    {
        CreatedApplicationStepResponse response = await Mediator.Send(createApplicationStepCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateApplicationStepCommand updateApplicationStepCommand)
    {
        UpdatedApplicationStepResponse response = await Mediator.Send(updateApplicationStepCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedApplicationStepResponse response = await Mediator.Send(new DeleteApplicationStepCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdApplicationStepResponse response = await Mediator.Send(new GetByIdApplicationStepQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListApplicationStepQuery getListApplicationStepQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListApplicationStepListItemDto> response = await Mediator.Send(getListApplicationStepQuery);
        return Ok(response);
    }
}