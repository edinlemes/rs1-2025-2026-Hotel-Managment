using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Hotel.Application.Modules.Hotels;

namespace Hotel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IMediator _mediator;
    public HotelsController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get all hotels with optional filtering and pagination
    /// </summary>
    /// <remarks>
    /// Query parameters:
    /// - searchTerm: Search by hotel name, code, or address
    /// - city: Filter by city
    /// - state: Filter by state
    /// - pageNumber: Page number (default 1)
    /// - pageSize: Page size (default 10, max 100)
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? searchTerm,
        [FromQuery] string? city,
        [FromQuery] string? state,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken ct = default)
    {
        var filterParams = new HotelFilterParams
        {
            SearchTerm = searchTerm,
            City = city,
            State = state,
            Page = pageNumber,
            PageSize = pageSize
        };

        var result = await _mediator.Send(new GetAllHotelsQuery(filterParams), ct);
        return Ok(result);
    }

    /// <summary>
    /// Get hotel by ID
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var dto = await _mediator.Send(new GetHotelByIdQuery(id), ct);
        if (dto is null) return NotFound();
        return Ok(dto);
    }

    /// <summary>
    /// Create a new hotel
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHotelRequest req, CancellationToken ct)
    {
        var created = await _mediator.Send(new CreateHotelCommand(req), ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Update an existing hotel
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateHotelRequest req, CancellationToken ct)
    {
        var updated = await _mediator.Send(new UpdateHotelCommand(id, req), ct);
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    /// <summary>
    /// Delete a hotel
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var ok = await _mediator.Send(new DeleteHotelCommand(id), ct);
        if (!ok) return NotFound();
        return NoContent();
    }
}
