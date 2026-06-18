using Microsoft.AspNetCore.Mvc;
using SoftwareManagement.Application.DTOs;
using SoftwareManagement.Application.Interfaces;

namespace SoftwareManagement.Controllers;

[ApiController]
[Route("api/versao")]
public class VersaoController : ControllerBase
{
    private readonly IVersaoService _service;

    public VersaoController(IVersaoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVersaoDto dto)
    {
        try
        {
            var criado = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = criado.IdVersao }, criado);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var versao = await _service.GetByIdAsync(id);

        if (versao is null)
            return NotFound();
            
        return Ok(versao);            
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateVersaoDto dto)
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

    [HttpGet("software/{idSoftware}")]
    public async Task<IActionResult> ListarVersoesSoftware(int idSoftware)
    {
        var versao = await _service.GetBySoftwareIdAsync(idSoftware);
        if (versao is null)
            return NotFound();
            
        return Ok(versao); 

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