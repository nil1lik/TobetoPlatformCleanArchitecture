using Application.Features.VideoDetailCategories.Commands.Create;
using Application.Features.VideoDetailCategories.Commands.Delete;
using Application.Features.VideoDetailCategories.Commands.Update;
using Application.Features.VideoDetailCategories.Queries.GetById;
using Application.Features.VideoDetailCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoDetailCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateVideoDetailCategoryCommand createVideoDetailCategoryCommand)
    {
        CreatedVideoDetailCategoryResponse response = await Mediator.Send(createVideoDetailCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateVideoDetailCategoryCommand updateVideoDetailCategoryCommand)
    {
        UpdatedVideoDetailCategoryResponse response = await Mediator.Send(updateVideoDetailCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedVideoDetailCategoryResponse response = await Mediator.Send(new DeleteVideoDetailCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdVideoDetailCategoryResponse response = await Mediator.Send(new GetByIdVideoDetailCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListVideoDetailCategoryQuery getListVideoDetailCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListVideoDetailCategoryListItemDto> response = await Mediator.Send(getListVideoDetailCategoryQuery);
        return Ok(response);
    }
}