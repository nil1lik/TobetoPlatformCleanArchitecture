using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Delete;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Queries.GetAsyncLessonsByCourseId;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using Application.Features.Courses.Queries.GetSyncLessonsByCourseId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseCommand createCourseCommand)
    {
        CreatedCourseResponse response = await Mediator.Send(createCourseCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseCommand updateCourseCommand)
    {
        UpdatedCourseResponse response = await Mediator.Send(updateCourseCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCourseResponse response = await Mediator.Send(new DeleteCourseCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCourseResponse response = await Mediator.Send(new GetByIdCourseQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getAsyncLesson/{id}")]
    public async Task<IActionResult> GetAsyncLessonsByCourseId([FromRoute] int id)
    {
        GetAsyncLessonsByCourseIdResponse response = await Mediator.Send(new GetAsyncLessonsByCourseIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getSyncLesson/{id}")]
    public async Task<IActionResult> GetSyncLessonsByCourseId([FromRoute] int id)
    {
        GetSyncLessonsByCourseIdResponse response = await Mediator.Send(new GetSyncLessonsByCourseIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseQuery getListCourseQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseListItemDto> response = await Mediator.Send(getListCourseQuery);
        return Ok(response);
    }

}