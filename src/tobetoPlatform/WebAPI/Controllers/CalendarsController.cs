using Application.Features.Calendars.Commands.Create;
using Application.Features.Calendars.Commands.Delete;
using Application.Features.Calendars.Commands.Update;
using Application.Features.Calendars.Queries.GetAllCalendar;
using Application.Features.Calendars.Queries.GetById;
using Application.Features.Calendars.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalendarsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCalendarCommand createCalendarCommand)
    {
        CreatedCalendarResponse response = await Mediator.Send(createCalendarCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCalendarCommand updateCalendarCommand)
    {
        UpdatedCalendarResponse response = await Mediator.Send(updateCalendarCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCalendarResponse response = await Mediator.Send(new DeleteCalendarCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCalendarResponse response = await Mediator.Send(new GetByIdCalendarQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCalendarQuery getListCalendarQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCalendarListItemDto> response = await Mediator.Send(getListCalendarQuery);
        return Ok(response);
    }

    [HttpGet("GetAllCalendar")]
    public async Task<IActionResult> GetListCalendar([FromQuery] PageRequest pageRequest)
    {
        GetAllCalenderQuery getListCalendarQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetAllCalenderListItemDto> response = await Mediator.Send(getListCalendarQuery);
        return Ok(response);
    }
}