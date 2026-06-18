using SoftwareManagement.Application.DTOs;
using SoftwareManagement.Application.Interfaces;
using SoftwareManagement.Data.Interfaces;
using SoftwareManagement.Domain;

namespace SoftwareManagement.Application.Services;

public class VersaoService : IVersaoService
{
    private readonly IVersaoRepository _repository;

    public VersaoService(IVersaoRepository repository)
    {
        _repository = repository;
    }

    private static VersaoResponseDto MapToResponseDto(Versao versao)
    {
        return new VersaoResponseDto(
            versao.IdVersao,
            versao.SoftwareId,
            versao.Descricao,
            versao.DataRelease,
            versao.Depreciado
        );
    }

    public async Task<VersaoResponseDto> CreateAsync(CreateVersaoDto dto)
        {
        var software = await _repository.GetByIdAsync(dto.SoftwareId);
        if (software is null)
            throw new KeyNotFoundException($"Software com id {dto.SoftwareId} não encontrado.");

        var versao = new Versao(dto.SoftwareId, dto.Descricao, dto.DataRelease, dto.Depreciado);
        var criado = await _repository.CreateAsync(versao);

        return MapToResponseDto(criado);
    }

    public async Task<VersaoResponseDto?> GetByIdAsync(int id)
    {
        var software = await _repository.GetByIdAsync(id);

        if (software is null)
            return null;

        return MapToResponseDto(software);
    }

    public async Task UpdateAsync(int id, CreateVersaoDto dto)
    {
        var versao = await _repository.GetByIdAsync(id);

        if (versao is null)
            throw new KeyNotFoundException($"Versao com id {id} nao encontrado.");

        versao.AtualizarDados(dto.Descricao, dto.DataRelease, dto.Depreciado);
        await _repository.UpdateAsync(versao);
    }

    public async Task<List<VersaoResponseDto>> GetBySoftwareIdAsync(int softwareId)
    {
        var versoes = await _repository.GetBySoftwareIdAsync(softwareId);
        return versoes.Select(MapToResponseDto).ToList();
    }
    public async Task DeleteAsync(int id)
    {
        var versao = await _repository.GetByIdAsync(id);

        if (versao is null)
            throw new KeyNotFoundException($"Versao com id {id} não encontrado.");

        await _repository.DeleteAsync(id);
    }
}
