using Application.Features.ExamResults.Commands.Create;
using Application.Features.ExamResults.Commands.Delete;
using Application.Features.ExamResults.Commands.Update;
using Application.Features.ExamResults.Queries.GetById;
using Application.Features.ExamResults.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamResultsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateExamResultCommand createExamResultCommand)
    {
        CreatedExamResultResponse response = await Mediator.Send(createExamResultCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateExamResultCommand updateExamResultCommand)
    {
        UpdatedExamResultResponse response = await Mediator.Send(updateExamResultCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedExamResultResponse response = await Mediator.Send(new DeleteExamResultCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdExamResultResponse response = await Mediator.Send(new GetByIdExamResultQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListExamResultQuery getListExamResultQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListExamResultListItemDto> response = await Mediator.Send(getListExamResultQuery);
        return Ok(response);
    }
}