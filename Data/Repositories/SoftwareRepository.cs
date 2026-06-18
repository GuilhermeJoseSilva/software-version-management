using Microsoft.EntityFrameworkCore;
using SoftwareManagement.Domain;
using SoftwareManagement.Data.Interfaces;

namespace SoftwareManagement.Data.Repositories;

public class SoftwareRepository : ISoftwareRepository
{
    private readonly AppDbContext _context;

    public SoftwareRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Software> CreateAsync(Software software)
    {
        _context.Softwares.Add(software);
        await _context.SaveChangesAsync();
        return software;
    }

    public async Task<Software?> GetByIdAsync(int id)
    {
        return await _context.Softwares.FindAsync(id);
    }

    public async Task<List<Software>> GetAllAsync()
    {
        return await _context.Softwares.ToListAsync();
    }

    public async Task UpdateAsync(Software software)
    {
        _context.Softwares.Update(software);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var software = await GetByIdAsync(id);
        if (software is not null)
        {
            _context.Softwares.Remove(software);
            await _context.SaveChangesAsync();
        }
    }
}