using Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Create;
using Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Delete;
using Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Update;
using Application.Features.LessonVideoDetailVideoDetailCategories.Queries.GetById;
using Application.Features.LessonVideoDetailVideoDetailCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonVideoDetailVideoDetailCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLessonVideoDetailVideoDetailCategoryCommand createLessonVideoDetailVideoDetailCategoryCommand)
    {
        CreatedLessonVideoDetailVideoDetailCategoryResponse response = await Mediator.Send(createLessonVideoDetailVideoDetailCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLessonVideoDetailVideoDetailCategoryCommand updateLessonVideoDetailVideoDetailCategoryCommand)
    {
        UpdatedLessonVideoDetailVideoDetailCategoryResponse response = await Mediator.Send(updateLessonVideoDetailVideoDetailCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLessonVideoDetailVideoDetailCategoryResponse response = await Mediator.Send(new DeleteLessonVideoDetailVideoDetailCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLessonVideoDetailVideoDetailCategoryResponse response = await Mediator.Send(new GetByIdLessonVideoDetailVideoDetailCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLessonVideoDetailVideoDetailCategoryQuery getListLessonVideoDetailVideoDetailCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLessonVideoDetailVideoDetailCategoryListItemDto> response = await Mediator.Send(getListLessonVideoDetailVideoDetailCategoryQuery);
        return Ok(response);
    }
}