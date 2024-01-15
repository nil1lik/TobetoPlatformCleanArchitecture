using Application.Features.ProfileAddresses.Commands.Create;
using Application.Features.ProfileAddresses.Commands.Delete;
using Application.Features.ProfileAddresses.Commands.Update;
using Application.Features.ProfileAddresses.Queries.GetById;
using Application.Features.ProfileAddresses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileAddressesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProfileAddressCommand createProfileAddressCommand)
    {
        CreatedProfileAddressResponse response = await Mediator.Send(createProfileAddressCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProfileAddressCommand updateProfileAddressCommand)
    {
        UpdatedProfileAddressResponse response = await Mediator.Send(updateProfileAddressCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProfileAddressResponse response = await Mediator.Send(new DeleteProfileAddressCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProfileAddressResponse response = await Mediator.Send(new GetByIdProfileAddressQuery { userId = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProfileAddressQuery getListProfileAddressQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProfileAddressListItemDto> response = await Mediator.Send(getListProfileAddressQuery);
        return Ok(response);
    }
}