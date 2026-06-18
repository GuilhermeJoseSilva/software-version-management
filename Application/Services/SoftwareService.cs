using SoftwareManagement.Application.DTOs;
using SoftwareManagement.Application.Interfaces;
using SoftwareManagement.Data.Interfaces;
using SoftwareManagement.Domain;

namespace SoftwareManagement.Application.Services;

public class SoftwareService : ISoftwareService
{
    private readonly ISoftwareRepository _repository;

    public SoftwareService(ISoftwareRepository repository)
    {
        _repository = repository;
    }

    private static SoftwareResponseDto MapToResponseDto(Software software)
    {
        return new SoftwareResponseDto(
            software.IdSoftware,
            software.Nome,
            software.Fornecedor,
            software.DataCriacao
        );
    }

    public async Task<SoftwareResponseDto> CreateAsync(CreateSoftwareDto dto)
    {
        var software = new Software(dto.Nome, dto.Fornecedor);
        var criado = await _repository.CreateAsync(software);

        return MapToResponseDto(criado);
    }

    public async Task<SoftwareResponseDto?> GetByIdAsync(int id)
    {
        var software = await _repository.GetByIdAsync(id);

        if (software is null)
            return null;

        return MapToResponseDto(software);
    }

    public async Task<List<SoftwareResponseDto>> GetAllAsync()
    {
        var softwares = await _repository.GetAllAsync();

        return softwares.Select(MapToResponseDto).ToList();
    }

    public async Task UpdateAsync(int id, CreateSoftwareDto dto)
    {
        var software = await _repository.GetByIdAsync(id);

        if (software is null)
            throw new KeyNotFoundException($"Software com id {id} não encontrado.");

        software.AtualizarDados(dto.Nome, dto.Fornecedor);
        await _repository.UpdateAsync(software);
    }

    public async Task DeleteAsync(int id)
    {
        var software = await _repository.GetByIdAsync(id);

        if (software is null)
            throw new KeyNotFoundException($"Software com id {id} não encontrado.");

        await _repository.DeleteAsync(id);
    }
}
