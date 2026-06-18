using SoftwareManagement.Domain;

namespace SoftwareManagement.Data.Interfaces;

public interface ISoftwareRepository
{
    Task<Software> CreateAsync(Software software);
    Task<Software?> GetByIdAsync(int id);
    Task<List<Software>> GetAllAsync();
    Task UpdateAsync(Software software);
    Task DeleteAsync(int id);
}