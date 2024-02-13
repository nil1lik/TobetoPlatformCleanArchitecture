using Application.Features.CourseLessons.Commands.Create;
using Application.Features.CourseLessons.Commands.Delete;
using Application.Features.CourseLessons.Commands.Update;
using Application.Features.CourseLessons.Queries.GetById;
using Application.Features.CourseLessons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseLessonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseLessonCommand createCourseLessonCommand)
    {
        CreatedCourseLessonResponse response = await Mediator.Send(createCourseLessonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseLessonCommand updateCourseLessonCommand)
    {
        UpdatedCourseLessonResponse response = await Mediator.Send(updateCourseLessonCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCourseLessonResponse response = await Mediator.Send(new DeleteCourseLessonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCourseLessonResponse response = await Mediator.Send(new GetByIdCourseLessonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseLessonQuery getListCourseLessonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseLessonListItemDto> response = await Mediator.Send(getListCourseLessonQuery);
        return Ok(response);
    }
}