using Application.Features.EducationAdmirations.Commands.Create;
using Application.Features.EducationAdmirations.Commands.Delete;
using Application.Features.EducationAdmirations.Commands.Update;
using Application.Features.EducationAdmirations.Queries.GetById;
using Application.Features.EducationAdmirations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationAdmirationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEducationAdmirationCommand createEducationAdmirationCommand)
    {
        CreatedEducationAdmirationResponse response = await Mediator.Send(createEducationAdmirationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEducationAdmirationCommand updateEducationAdmirationCommand)
    {
        UpdatedEducationAdmirationResponse response = await Mediator.Send(updateEducationAdmirationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedEducationAdmirationResponse response = await Mediator.Send(new DeleteEducationAdmirationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdEducationAdmirationResponse response = await Mediator.Send(new GetByIdEducationAdmirationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEducationAdmirationQuery getListEducationAdmirationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEducationAdmirationListItemDto> response = await Mediator.Send(getListEducationAdmirationQuery);
        return Ok(response);
    }
}