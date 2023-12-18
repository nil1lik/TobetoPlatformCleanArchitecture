using Application.Features.CourseClasses.Commands.Create;
using Application.Features.CourseClasses.Commands.Delete;
using Application.Features.CourseClasses.Commands.Update;
using Application.Features.CourseClasses.Queries.GetById;
using Application.Features.CourseClasses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseClassesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseClassCommand createCourseClassCommand)
    {
        CreatedCourseClassResponse response = await Mediator.Send(createCourseClassCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseClassCommand updateCourseClassCommand)
    {
        UpdatedCourseClassResponse response = await Mediator.Send(updateCourseClassCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCourseClassResponse response = await Mediator.Send(new DeleteCourseClassCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCourseClassResponse response = await Mediator.Send(new GetByIdCourseClassQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseClassQuery getListCourseClassQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseClassListItemDto> response = await Mediator.Send(getListCourseClassQuery);
        return Ok(response);
    }
}