using Application.Features.ProfileGraduations.Commands.Create;
using Application.Features.ProfileGraduations.Commands.Delete;
using Application.Features.ProfileGraduations.Commands.Update;
using Application.Features.ProfileGraduations.Queries.GetAllGraduationByUserId;
using Application.Features.ProfileGraduations.Queries.GetById;
using Application.Features.ProfileGraduations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileGraduationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileGraduationCommand createProfileGraduationCommand)
    {
        CreatedProfileGraduationResponse response = await Mediator.Send(createProfileGraduationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileGraduationCommand updateProfileGraduationCommand)
    {
        UpdatedProfileGraduationResponse response = await Mediator.Send(updateProfileGraduationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileGraduationResponse response = await Mediator.Send(new DeleteProfileGraduationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileGraduationResponse response = await Mediator.Send(new GetByIdProfileGraduationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileGraduationQuery getListProfileGraduationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileGraduationListItemDto> response = await Mediator.Send(getListProfileGraduationQuery);
        return Ok(response);
    }

    [HttpGet("GetAllGraduation")]
    public async Task<IActionResult> GetAllgraduationByUserId([FromQuery] PageRequest pageRequest)
    {
        GetListGraduationByUserIdQuery getListProfileGraduationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGraduationItemResponse> response = await Mediator.Send(getListProfileGraduationQuery);
        return Ok(response);
    }
}