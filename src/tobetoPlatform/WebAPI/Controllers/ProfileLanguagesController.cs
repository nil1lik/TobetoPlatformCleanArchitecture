using Application.Features.ProfileLanguages.Commands.Create;
using Application.Features.ProfileLanguages.Commands.Delete;
using Application.Features.ProfileLanguages.Commands.Update;
using Application.Features.ProfileLanguages.Queries.GetAllLanguageByUserId;
using Application.Features.ProfileLanguages.Queries.GetById;
using Application.Features.ProfileLanguages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileLanguagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileLanguageCommand createProfileLanguageCommand)
    {
        CreatedProfileLanguageResponse response = await Mediator.Send(createProfileLanguageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileLanguageCommand updateProfileLanguageCommand)
    {
        UpdatedProfileLanguageResponse response = await Mediator.Send(updateProfileLanguageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileLanguageResponse response = await Mediator.Send(new DeleteProfileLanguageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileLanguageResponse response = await Mediator.Send(new GetByIdProfileLanguageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileLanguageQuery getListProfileLanguageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileLanguageListItemDto> response = await Mediator.Send(getListProfileLanguageQuery);
        return Ok(response);
    }

    [HttpGet("GetAllLanguage")]
    public async Task<IActionResult> GetAllLanguageByUserId([FromQuery] PageRequest pageRequest)
    {
        GetAllLanguageByUserIdQuery getListProfileLanguageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetAllLanguageByUserIdResponse> response = await Mediator.Send(getListProfileLanguageQuery);
        return Ok(response);
    }
}