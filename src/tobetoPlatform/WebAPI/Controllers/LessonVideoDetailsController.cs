using Application.Features.LessonVideoDetails.Commands.Create;
using Application.Features.LessonVideoDetails.Commands.Delete;
using Application.Features.LessonVideoDetails.Commands.Update;
using Application.Features.LessonVideoDetails.Queries.GetById;
using Application.Features.LessonVideoDetails.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonVideoDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLessonVideoDetailCommand createLessonVideoDetailCommand)
    {
        CreatedLessonVideoDetailResponse response = await Mediator.Send(createLessonVideoDetailCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLessonVideoDetailCommand updateLessonVideoDetailCommand)
    {
        UpdatedLessonVideoDetailResponse response = await Mediator.Send(updateLessonVideoDetailCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLessonVideoDetailResponse response = await Mediator.Send(new DeleteLessonVideoDetailCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLessonVideoDetailResponse response = await Mediator.Send(new GetByIdLessonVideoDetailQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLessonVideoDetailQuery getListLessonVideoDetailQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLessonVideoDetailListItemDto> response = await Mediator.Send(getListLessonVideoDetailQuery);
        return Ok(response);
    }
}