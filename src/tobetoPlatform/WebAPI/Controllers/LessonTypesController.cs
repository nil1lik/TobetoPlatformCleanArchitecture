using Application.Features.LessonTypes.Commands.Create;
using Application.Features.LessonTypes.Commands.Delete;
using Application.Features.LessonTypes.Commands.Update;
using Application.Features.LessonTypes.Queries.GetById;
using Application.Features.LessonTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLessonTypeCommand createLessonTypeCommand)
    {
        CreatedLessonTypeResponse response = await Mediator.Send(createLessonTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLessonTypeCommand updateLessonTypeCommand)
    {
        UpdatedLessonTypeResponse response = await Mediator.Send(updateLessonTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLessonTypeResponse response = await Mediator.Send(new DeleteLessonTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLessonTypeResponse response = await Mediator.Send(new GetByIdLessonTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLessonTypeQuery getListLessonTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLessonTypeListItemDto> response = await Mediator.Send(getListLessonTypeQuery);
        return Ok(response);
    }
}