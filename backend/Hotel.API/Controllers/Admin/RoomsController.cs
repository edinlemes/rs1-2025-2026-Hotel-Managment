using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hotel.Application.Modules.Rooms;

namespace Hotel.API.Controllers.Admin;

[ApiController]
[Route("api/admin/[controller]")]
[Authorize(Roles = "Administrator")]
public class RoomsController : ControllerBase
{
    private readonly RoomsCrud _service;

    public RoomsController(RoomsCrud service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] bool includeDeleted = false, CancellationToken ct = default)
    {
        var list = await _service.GetAllAsync(includeDeleted, ct);
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, [FromQuery] bool includeDeleted = false, CancellationToken ct = default)
    {
        var dto = await _service.GetByIdAsync(id, includeDeleted, ct);
        if (dto is null) return NotFound();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomDto req, CancellationToken ct = default)
    {
        var created = await _service.CreateAsync(req, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRoomDto req, CancellationToken ct = default)
    {
        var ok = await _service.UpdateAsync(id, req, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct = default)
    {
        var ok = await _service.DeleteAsync(id, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpPost("{id:int}/restore")]
    public async Task<IActionResult> Restore(int id, CancellationToken ct = default)
    {
        var ok = await _service.RestoreAsync(id, ct);
        if (!ok) return NotFound();
        return NoContent();
    }
}
