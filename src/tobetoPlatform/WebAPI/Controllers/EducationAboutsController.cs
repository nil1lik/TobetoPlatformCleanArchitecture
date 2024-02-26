using Application.Features.EducationAbouts.Commands.Create;
using Application.Features.EducationAbouts.Commands.Delete;
using Application.Features.EducationAbouts.Commands.Update;
using Application.Features.EducationAbouts.Queries.GetById;
using Application.Features.EducationAbouts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationAboutsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEducationAboutCommand createEducationAboutCommand)
    {
        CreatedEducationAboutResponse response = await Mediator.Send(createEducationAboutCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEducationAboutCommand updateEducationAboutCommand)
    {
        UpdatedEducationAboutResponse response = await Mediator.Send(updateEducationAboutCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedEducationAboutResponse response = await Mediator.Send(new DeleteEducationAboutCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdEducationAboutResponse response = await Mediator.Send(new GetByIdEducationAboutQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEducationAboutQuery getListEducationAboutQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEducationAboutListItemDto> response = await Mediator.Send(getListEducationAboutQuery);
        return Ok(response);
    }
}