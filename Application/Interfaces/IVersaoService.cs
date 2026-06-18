using SoftwareManagement.Application.DTOs;

namespace SoftwareManagement.Application.Interfaces;

public interface IVersaoService
{
     Task<VersaoResponseDto> CreateAsync(CreateVersaoDto dto);
    Task<VersaoResponseDto?> GetByIdAsync(int id);
    Task<List<VersaoResponseDto>> GetBySoftwareIdAsync(int softwareId);
    Task UpdateAsync(int id, CreateVersaoDto dto);
    Task DeleteAsync(int id);
}