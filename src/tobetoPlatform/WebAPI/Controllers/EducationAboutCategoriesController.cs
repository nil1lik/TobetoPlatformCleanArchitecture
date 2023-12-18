using Application.Features.EducationAboutCategories.Commands.Create;
using Application.Features.EducationAboutCategories.Commands.Delete;
using Application.Features.EducationAboutCategories.Commands.Update;
using Application.Features.EducationAboutCategories.Queries.GetById;
using Application.Features.EducationAboutCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationAboutCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEducationAboutCategoryCommand createEducationAboutCategoryCommand)
    {
        CreatedEducationAboutCategoryResponse response = await Mediator.Send(createEducationAboutCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEducationAboutCategoryCommand updateEducationAboutCategoryCommand)
    {
        UpdatedEducationAboutCategoryResponse response = await Mediator.Send(updateEducationAboutCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedEducationAboutCategoryResponse response = await Mediator.Send(new DeleteEducationAboutCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdEducationAboutCategoryResponse response = await Mediator.Send(new GetByIdEducationAboutCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEducationAboutCategoryQuery getListEducationAboutCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEducationAboutCategoryListItemDto> response = await Mediator.Send(getListEducationAboutCategoryQuery);
        return Ok(response);
    }
}