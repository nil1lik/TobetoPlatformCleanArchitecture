using Application.Features.ProfileApplicationForms.Commands.Create;
using Application.Features.ProfileApplicationForms.Commands.Delete;
using Application.Features.ProfileApplicationForms.Commands.Update;
using Application.Features.ProfileApplicationForms.Queries.GetById;
using Application.Features.ProfileApplicationForms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileApplicationFormsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileApplicationFormCommand createProfileApplicationFormCommand)
    {
        CreatedProfileApplicationFormResponse response = await Mediator.Send(createProfileApplicationFormCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileApplicationFormCommand updateProfileApplicationFormCommand)
    {
        UpdatedProfileApplicationFormResponse response = await Mediator.Send(updateProfileApplicationFormCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileApplicationFormResponse response = await Mediator.Send(new DeleteProfileApplicationFormCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileApplicationFormResponse response = await Mediator.Send(new GetByIdProfileApplicationFormQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileApplicationFormQuery getListProfileApplicationFormQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileApplicationFormListItemDto> response = await Mediator.Send(getListProfileApplicationFormQuery);
        return Ok(response);
    }
}