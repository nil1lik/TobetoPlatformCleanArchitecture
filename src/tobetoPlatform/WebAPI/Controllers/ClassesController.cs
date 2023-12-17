using Application.Features.Classes.Commands.Create;
using Application.Features.Classes.Commands.Delete;
using Application.Features.Classes.Commands.Update;
using Application.Features.Classes.Queries.GetById;
using Application.Features.Classes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateClassCommand createClassCommand)
    {
        CreatedClassResponse response = await Mediator.Send(createClassCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClassCommand updateClassCommand)
    {
        UpdatedClassResponse response = await Mediator.Send(updateClassCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedClassResponse response = await Mediator.Send(new DeleteClassCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdClassResponse response = await Mediator.Send(new GetByIdClassQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListClassQuery getListClassQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListClassListItemDto> response = await Mediator.Send(getListClassQuery);
        return Ok(response);
    }
}