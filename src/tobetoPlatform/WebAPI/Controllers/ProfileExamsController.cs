using Application.Features.ProfileExams.Commands.Create;
using Application.Features.ProfileExams.Commands.Delete;
using Application.Features.ProfileExams.Commands.Update;
using Application.Features.ProfileExams.Queries.GetAllExamByUserId;
using Application.Features.ProfileExams.Queries.GetById;
using Application.Features.ProfileExams.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileExamsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileExamCommand createProfileExamCommand)
    {
        CreatedProfileExamResponse response = await Mediator.Send(createProfileExamCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileExamCommand updateProfileExamCommand)
    {
        UpdatedProfileExamResponse response = await Mediator.Send(updateProfileExamCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileExamResponse response = await Mediator.Send(new DeleteProfileExamCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileExamResponse response = await Mediator.Send(new GetByIdProfileExamQuery { Id = id });
        return Ok(response);
    }

    [HttpGet] 
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileExamQuery getListProfileExamQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileExamListItemDto> response = await Mediator.Send(getListProfileExamQuery);
        return Ok(response);
    }

    [HttpGet("GetAllExam")]
    public async Task<IActionResult> GetallExamByUserId([FromQuery] PageRequest pageRequest)
    {
        GetListExamByUserIdQuery getListProfileExamQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetAllExamByUserIdResponse> response = await Mediator.Send(getListProfileExamQuery);
        return Ok(response);
    }
}