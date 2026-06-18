using Microsoft.EntityFrameworkCore;
using SoftwareManagement.Domain;
using SoftwareManagement.Data.Interfaces;

namespace SoftwareManagement.Data.Repositories;

public class VersaoRepository : IVersaoRepository
{
    private readonly AppDbContext _context;

    public VersaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Versao> CreateAsync(Versao versao)
    {
        _context.Versoes.Add(versao);
        await _context.SaveChangesAsync();
        return versao;
    }

    public async Task<Versao?> GetByIdAsync(int id)
    {
        return await _context.Versoes.FindAsync(id);
    }

    public async Task<List<Versao>> GetAllAsync()
    {
        return await _context.Versoes.ToListAsync();
    }

    public async Task UpdateAsync(Versao versao)
    {
        _context.Versoes.Update(versao);
        await _context.SaveChangesAsync();

    }

    public async Task<List<Versao>> GetBySoftwareIdAsync(int softwareId)
    {
        return await _context.Versoes.Where(v => v.SoftwareId == softwareId).ToListAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var versao = await GetByIdAsync(id);
        if(versao is not null)
        {
            _context.Versoes.Remove(versao);
            await _context.SaveChangesAsync();
        }
    }
}