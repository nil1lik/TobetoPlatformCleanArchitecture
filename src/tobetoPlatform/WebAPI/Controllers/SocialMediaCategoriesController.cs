using Application.Features.SocialMediaCategories.Commands.Create;
using Application.Features.SocialMediaCategories.Commands.Delete;
using Application.Features.SocialMediaCategories.Commands.Update;
using Application.Features.SocialMediaCategories.Queries.GetById;
using Application.Features.SocialMediaCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediaCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSocialMediaCategoryCommand createSocialMediaCategoryCommand)
    {
        CreatedSocialMediaCategoryResponse response = await Mediator.Send(createSocialMediaCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSocialMediaCategoryCommand updateSocialMediaCategoryCommand)
    {
        UpdatedSocialMediaCategoryResponse response = await Mediator.Send(updateSocialMediaCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedSocialMediaCategoryResponse response = await Mediator.Send(new DeleteSocialMediaCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdSocialMediaCategoryResponse response = await Mediator.Send(new GetByIdSocialMediaCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSocialMediaCategoryQuery getListSocialMediaCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSocialMediaCategoryListItemDto> response = await Mediator.Send(getListSocialMediaCategoryQuery);
        return Ok(response);
    }
}