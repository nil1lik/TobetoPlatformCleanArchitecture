using Application.Features.VideoLanguages.Commands.Create;
using Application.Features.VideoLanguages.Commands.Delete;
using Application.Features.VideoLanguages.Commands.Update;
using Application.Features.VideoLanguages.Queries.GetById;
using Application.Features.VideoLanguages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoLanguagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateVideoLanguageCommand createVideoLanguageCommand)
    {
        CreatedVideoLanguageResponse response = await Mediator.Send(createVideoLanguageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateVideoLanguageCommand updateVideoLanguageCommand)
    {
        UpdatedVideoLanguageResponse response = await Mediator.Send(updateVideoLanguageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedVideoLanguageResponse response = await Mediator.Send(new DeleteVideoLanguageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdVideoLanguageResponse response = await Mediator.Send(new GetByIdVideoLanguageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListVideoLanguageQuery getListVideoLanguageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListVideoLanguageListItemDto> response = await Mediator.Send(getListVideoLanguageQuery);
        return Ok(response);
    }
}