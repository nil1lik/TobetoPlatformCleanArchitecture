using Application.Features.AsyncLessons.Commands.Create;
using Application.Features.AsyncLessons.Commands.Delete;
using Application.Features.AsyncLessons.Commands.Update;
using Application.Features.AsyncLessons.Queries.GetById;
using Application.Features.AsyncLessons.Queries.GetLessonDetailByAsyncLessonId;
using Application.Features.AsyncLessons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AsyncLessonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAsyncLessonCommand createAsyncLessonCommand)
    {
        CreatedAsyncLessonResponse response = await Mediator.Send(createAsyncLessonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAsyncLessonCommand updateAsyncLessonCommand)
    {
        UpdatedAsyncLessonResponse response = await Mediator.Send(updateAsyncLessonCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAsyncLessonResponse response = await Mediator.Send(new DeleteAsyncLessonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAsyncLessonResponse response = await Mediator.Send(new GetByIdAsyncLessonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getLessonDetail/{id}")]
    public async Task<IActionResult> getLessonDetailByAsyncLessonId([FromRoute] int id)
    {
        GetLessonDetailByAsyncLessonIdResponse response = await Mediator.Send(new GetLessonDetailByAsyncLessonIdQuery { Id = id });
        return Ok(response); 
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAsyncLessonQuery getListAsyncLessonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAsyncLessonListItemDto> response = await Mediator.Send(getListAsyncLessonQuery);
        return Ok(response);
    }
}