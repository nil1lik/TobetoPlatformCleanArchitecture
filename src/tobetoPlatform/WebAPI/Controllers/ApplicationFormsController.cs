using Application.Features.ApplicationForms.Commands.Create;
using Application.Features.ApplicationForms.Commands.Delete;
using Application.Features.ApplicationForms.Commands.Update;
using Application.Features.ApplicationForms.Queries.GetById;
using Application.Features.ApplicationForms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationFormsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateApplicationFormCommand createApplicationFormCommand)
    {
        CreatedApplicationFormResponse response = await Mediator.Send(createApplicationFormCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateApplicationFormCommand updateApplicationFormCommand)
    {
        UpdatedApplicationFormResponse response = await Mediator.Send(updateApplicationFormCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedApplicationFormResponse response = await Mediator.Send(new DeleteApplicationFormCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdApplicationFormResponse response = await Mediator.Send(new GetByIdApplicationFormQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListApplicationFormQuery getListApplicationFormQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListApplicationFormListItemDto> response = await Mediator.Send(getListApplicationFormQuery);
        return Ok(response);
    }
}