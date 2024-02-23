using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Delete;
using Application.Features.UserProfiles.Commands.Update;
using Application.Features.UserProfiles.Queries.GetAllExperienceByUserId;
using Application.Features.UserProfiles.Queries.GetAllGraduationByUserId;
using Application.Features.UserProfiles.Queries.GetAllSkillByUserId;
using Application.Features.UserProfiles.Queries.GetById;
using Application.Features.UserProfiles.Queries.GetByUserId;
using Application.Features.UserProfiles.Queries.GetExperienceByUserId;
using Application.Features.UserProfiles.Queries.GetList;
using Application.Features.UserProfiles.Queries.GetUserDetail;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfilesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserProfileCommand createUserProfileCommand)
    {
        CreatedUserProfileResponse response = await Mediator.Send(createUserProfileCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserProfileCommand updateUserProfileCommand)
    {
        UpdatedUserProfileResponse response = await Mediator.Send(updateUserProfileCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedUserProfileResponse response = await Mediator.Send(new DeleteUserProfileCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetUserDetailDto response = await Mediator.Send(new GetUserDetailQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getByUserId/{id}")]
    public async Task<IActionResult> GetByUserId([FromRoute] int id)
    {
        GetByUserIdUserProfileResponse response = await Mediator.Send(new GetByUserIdUserProfileQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserProfileQuery getListUserProfileQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserProfileListItemDto> response = await Mediator.Send(getListUserProfileQuery);
        return Ok(response);
    }

    [HttpGet("GetAllSkill/{id}")]
    public async Task<IActionResult> GetBySkillId([FromRoute] int id)
    {
        GetListSkillByUserIdResponse response = await Mediator.Send(new GetAllSkillByUserIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getAllGraduation/{id}")]
    public async Task<IActionResult> GetByGraduationId([FromRoute] int id)
    {
        GetListGraduationByUserIdResponse response = await Mediator.Send(new GetAllGraduationByUserIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getAllExperience/{id}")]
    public async Task<IActionResult> GetByExperienceId([FromRoute] int id)
    {
        GetListExperienceByUserIdResponse response = await Mediator.Send(new GetAllExperienceByUserIdQuery { Id = id });
        return Ok(response);
    }
}