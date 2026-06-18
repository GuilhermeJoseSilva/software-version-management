using SoftwareManagement.Domain;

namespace SoftwareManagement.Data.Interfaces;

public interface IVersaoRepository
{
    Task<Versao> CreateAsync(Versao versao);
    Task<Versao?> GetByIdAsync(int id);
    Task<List<Versao>> GetBySoftwareIdAsync(int softwareId);
    Task UpdateAsync(Versao versao);
    Task DeleteAsync(int id);
}