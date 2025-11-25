
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Hotel.Application.Modules.Persons;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IMediator _mediator;
    public PersonsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var list = await _mediator.Send(new GetAllPersonsQuery(), ct);
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var dto = await _mediator.Send(new GetPersonByIdQuery(id), ct);
        if (dto is null) return NotFound();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonRequest req, CancellationToken ct)
    {
        var created = await _mediator.Send(new CreatePersonCommand(req), ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePersonRequest req, CancellationToken ct)
    {
        var updated = await _mediator.Send(new UpdatePersonCommand(id, req), ct);
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var ok = await _mediator.Send(new DeletePersonCommand(id), ct);
        if (!ok) return NotFound();
        return NoContent();
    }
}
