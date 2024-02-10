using Application.Features.Calendar.Queries.GetList;
using Application.Features.CourseInstructors.Commands.Create;
using Application.Features.CourseInstructors.Commands.Delete;
using Application.Features.CourseInstructors.Commands.Update;
using Application.Features.CourseInstructors.Queries.GetById;
using Application.Features.CourseInstructors.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseInstructorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseInstructorCommand createCourseInstructorCommand)
    {
        CreatedCourseInstructorResponse response = await Mediator.Send(createCourseInstructorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseInstructorCommand updateCourseInstructorCommand)
    {
        UpdatedCourseInstructorResponse response = await Mediator.Send(updateCourseInstructorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCourseInstructorResponse response = await Mediator.Send(new DeleteCourseInstructorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCourseInstructorResponse response = await Mediator.Send(new GetByIdCourseInstructorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseInstructorQuery getListCourseInstructorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseInstructorListItemDto> response = await Mediator.Send(getListCourseInstructorQuery);
        return Ok(response);
    }

}