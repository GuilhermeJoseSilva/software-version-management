using Microsoft.AspNetCore.Mvc;
using SoftwareManagement.Application.DTOs;
using SoftwareManagement.Application.Interfaces;

namespace SoftwareManagement.Controllers;

[ApiController]
[Route("api/software")]
public class SoftwareController : ControllerBase
{
    private readonly ISoftwareService _service;

    public SoftwareController(ISoftwareService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSoftwareDto dto)
    {
        var criado = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new {id = criado.Id}, criado);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var softwares = await _service.GetAllAsync();
        return Ok(softwares);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var software = await _service.GetByIdAsync(id);

        if (software is null)
            return NotFound();
            
        return Ok(software);            
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateSoftwareDto dto)
    {
        try
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
       try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}