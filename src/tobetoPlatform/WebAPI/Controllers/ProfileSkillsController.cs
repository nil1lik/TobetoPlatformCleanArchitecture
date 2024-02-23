using Application.Features.ProfileSkills.Commands.Create;
using Application.Features.ProfileSkills.Commands.Delete;
using Application.Features.ProfileSkills.Commands.Update;
using Application.Features.ProfileSkills.Queries.GetById;
using Application.Features.ProfileSkills.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileSkillsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileSkillCommand createProfileSkillCommand)
    {
        CreatedProfileSkillResponse response = await Mediator.Send(createProfileSkillCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileSkillCommand updateProfileSkillCommand)
    {
        UpdatedProfileSkillResponse response = await Mediator.Send(updateProfileSkillCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileSkillResponse response = await Mediator.Send(new DeleteProfileSkillCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileSkillResponse response = await Mediator.Send(new GetByIdProfileSkillQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileSkillQuery getListProfileSkillQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileSkillListItemDto> response = await Mediator.Send(getListProfileSkillQuery);
        return Ok(response);
    }


}