using Application.Features.VideoDetailSubcategories.Commands.Create;
using Application.Features.VideoDetailSubcategories.Commands.Delete;
using Application.Features.VideoDetailSubcategories.Commands.Update;
using Application.Features.VideoDetailSubcategories.Queries.GetById;
using Application.Features.VideoDetailSubcategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoDetailSubcategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateVideoDetailSubcategoryCommand createVideoDetailSubcategoryCommand)
    {
        CreatedVideoDetailSubcategoryResponse response = await Mediator.Send(createVideoDetailSubcategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateVideoDetailSubcategoryCommand updateVideoDetailSubcategoryCommand)
    {
        UpdatedVideoDetailSubcategoryResponse response = await Mediator.Send(updateVideoDetailSubcategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedVideoDetailSubcategoryResponse response = await Mediator.Send(new DeleteVideoDetailSubcategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdVideoDetailSubcategoryResponse response = await Mediator.Send(new GetByIdVideoDetailSubcategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListVideoDetailSubcategoryQuery getListVideoDetailSubcategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListVideoDetailSubcategoryListItemDto> response = await Mediator.Send(getListVideoDetailSubcategoryQuery);
        return Ok(response);
    }
}