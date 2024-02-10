using Application.Features.EducationPaths.Commands.Create;
using Application.Features.EducationPaths.Commands.Delete;
using Application.Features.EducationPaths.Commands.Update;
using Application.Features.EducationPaths.Queries.GetById;
using Application.Features.EducationPaths.Queries.GetEducationPathDetailById;
using Application.Features.EducationPaths.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationPathsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEducationPathCommand createEducationPathCommand)
    {
        CreatedEducationPathResponse response = await Mediator.Send(createEducationPathCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEducationPathCommand updateEducationPathCommand)
    {
        UpdatedEducationPathResponse response = await Mediator.Send(updateEducationPathCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedEducationPathResponse response = await Mediator.Send(new DeleteEducationPathCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdEducationPathResponse response = await Mediator.Send(new GetByIdEducationPathQuery { Id = id });
        return Ok(response);
    }
    [HttpGet("EducationPathDetail/{id}")]
    public async Task<IActionResult> GetEducationPathDetailById([FromRoute] int id)
    {
        GetEducationPathDetailByIdDto response = await Mediator.Send(new GetEducationPathDetailByIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEducationPathQuery getListEducationPathQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEducationPathListItemDto> response = await Mediator.Send(getListEducationPathQuery);
        return Ok(response);
    }
}