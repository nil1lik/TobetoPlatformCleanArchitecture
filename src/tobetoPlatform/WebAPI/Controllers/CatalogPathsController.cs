using Application.Features.CatalogPaths.Commands.Create;
using Application.Features.CatalogPaths.Commands.Delete;
using Application.Features.CatalogPaths.Commands.Update;
using Application.Features.CatalogPaths.Queries.GetById;
using Application.Features.CatalogPaths.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogPathsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCatalogPathCommand createCatalogPathCommand)
    {
        CreatedCatalogPathResponse response = await Mediator.Send(createCatalogPathCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCatalogPathCommand updateCatalogPathCommand)
    {
        UpdatedCatalogPathResponse response = await Mediator.Send(updateCatalogPathCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCatalogPathResponse response = await Mediator.Send(new DeleteCatalogPathCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCatalogPathResponse response = await Mediator.Send(new GetByIdCatalogPathQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCatalogPathQuery getListCatalogPathQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCatalogPathListItemDto> response = await Mediator.Send(getListCatalogPathQuery);
        return Ok(response);
    }
}