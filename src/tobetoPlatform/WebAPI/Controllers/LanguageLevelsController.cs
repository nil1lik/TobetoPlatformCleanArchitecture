using Application.Features.LanguageLevels.Commands.Create;
using Application.Features.LanguageLevels.Commands.Delete;
using Application.Features.LanguageLevels.Commands.Update;
using Application.Features.LanguageLevels.Queries.GetById;
using Application.Features.LanguageLevels.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageLevelsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLanguageLevelCommand createLanguageLevelCommand)
    {
        CreatedLanguageLevelResponse response = await Mediator.Send(createLanguageLevelCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLanguageLevelCommand updateLanguageLevelCommand)
    {
        UpdatedLanguageLevelResponse response = await Mediator.Send(updateLanguageLevelCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLanguageLevelResponse response = await Mediator.Send(new DeleteLanguageLevelCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLanguageLevelResponse response = await Mediator.Send(new GetByIdLanguageLevelQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLanguageLevelQuery getListLanguageLevelQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLanguageLevelListItemDto> response = await Mediator.Send(getListLanguageLevelQuery);
        return Ok(response);
    }
}