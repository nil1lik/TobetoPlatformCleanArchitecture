using Application.Features.ProfileLessons.Commands.Create;
using Application.Features.ProfileLessons.Commands.Delete;
using Application.Features.ProfileLessons.Commands.Update;
using Application.Features.ProfileLessons.Queries.GetById;
using Application.Features.ProfileLessons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileLessonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileLessonCommand createProfileLessonCommand)
    {
        CreatedProfileLessonResponse response = await Mediator.Send(createProfileLessonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileLessonCommand updateProfileLessonCommand)
    {
        UpdatedProfileLessonResponse response = await Mediator.Send(updateProfileLessonCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileLessonResponse response = await Mediator.Send(new DeleteProfileLessonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileLessonResponse response = await Mediator.Send(new GetByIdProfileLessonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileLessonQuery getListProfileLessonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileLessonListItemDto> response = await Mediator.Send(getListProfileLessonQuery);
        return Ok(response);
    }
}