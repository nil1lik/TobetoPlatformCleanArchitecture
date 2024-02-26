using Application.Features.SyncLessons.Commands.Create;
using Application.Features.SyncLessons.Commands.Delete;
using Application.Features.SyncLessons.Commands.Update;
using Application.Features.SyncLessons.Queries.GetById;
using Application.Features.SyncLessons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SyncLessonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSyncLessonCommand createSyncLessonCommand)
    {
        CreatedSyncLessonResponse response = await Mediator.Send(createSyncLessonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSyncLessonCommand updateSyncLessonCommand)
    {
        UpdatedSyncLessonResponse response = await Mediator.Send(updateSyncLessonCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedSyncLessonResponse response = await Mediator.Send(new DeleteSyncLessonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdSyncLessonResponse response = await Mediator.Send(new GetByIdSyncLessonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSyncLessonQuery getListSyncLessonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSyncLessonListItemDto> response = await Mediator.Send(getListSyncLessonQuery);
        return Ok(response);
    }
}