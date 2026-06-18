using SoftwareManagement.Application.DTOs;

namespace SoftwareManagement.Application.Interfaces;

public interface ISoftwareService
{
    Task<SoftwareResponseDto> CreateAsync(CreateSoftwareDto dto);
    Task<SoftwareResponseDto?> GetByIdAsync(int id);
    Task<List<SoftwareResponseDto>> GetAllAsync();
    Task UpdateAsync(int id, CreateSoftwareDto dto);
    Task DeleteAsync(int id);
}