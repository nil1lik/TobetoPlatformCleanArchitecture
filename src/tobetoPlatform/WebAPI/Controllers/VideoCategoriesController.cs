using Application.Features.VideoCategories.Commands.Create;
using Application.Features.VideoCategories.Commands.Delete;
using Application.Features.VideoCategories.Commands.Update;
using Application.Features.VideoCategories.Queries.GetById;
using Application.Features.VideoCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateVideoCategoryCommand createVideoCategoryCommand)
    {
        CreatedVideoCategoryResponse response = await Mediator.Send(createVideoCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateVideoCategoryCommand updateVideoCategoryCommand)
    {
        UpdatedVideoCategoryResponse response = await Mediator.Send(updateVideoCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedVideoCategoryResponse response = await Mediator.Send(new DeleteVideoCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdVideoCategoryResponse response = await Mediator.Send(new GetByIdVideoCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListVideoCategoryQuery getListVideoCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListVideoCategoryListItemDto> response = await Mediator.Send(getListVideoCategoryQuery);
        return Ok(response);
    }
}