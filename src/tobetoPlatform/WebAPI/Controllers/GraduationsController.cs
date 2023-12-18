using Application.Features.Graduations.Commands.Create;
using Application.Features.Graduations.Commands.Delete;
using Application.Features.Graduations.Commands.Update;
using Application.Features.Graduations.Queries.GetById;
using Application.Features.Graduations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GraduationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGraduationCommand createGraduationCommand)
    {
        CreatedGraduationResponse response = await Mediator.Send(createGraduationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGraduationCommand updateGraduationCommand)
    {
        UpdatedGraduationResponse response = await Mediator.Send(updateGraduationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedGraduationResponse response = await Mediator.Send(new DeleteGraduationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdGraduationResponse response = await Mediator.Send(new GetByIdGraduationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGraduationQuery getListGraduationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGraduationListItemDto> response = await Mediator.Send(getListGraduationQuery);
        return Ok(response);
    }
}