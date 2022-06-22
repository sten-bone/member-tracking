using MemberTracking.Data.DbContext;
using MemberTracking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MemberTracking.Data.Repositories;

public interface IMemberRepository
{
    Task<List<Member>> GetAllMembers();
    Task<Member?> GetMemberById(int id);
    Task<bool> CreateMember(Member member);
    Task<bool> UpdateMember(int id, Member member);
    Task<bool> DeleteMember(int id);
    Task SaveChanges();
}

public class MembersRepository : IMemberRepository
{
    private readonly MemberDbContext _context;

    public MembersRepository(MemberDbContext context)
    {
        _context = context;
    }

    public async Task<List<Member>> GetAllMembers()
    {
        return await _context.Members.AsNoTracking().ToListAsync();
    }

    public async Task<Member?> GetMemberById(int id)
    {
        return await _context.Members.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> CreateMember(Member member)
    {
        // validation handled at controller level
        var result = await _context.Members.AddAsync(member);
        return result.Entity.Id > 0;
    }

    public async Task<bool> UpdateMember(int id, Member member)
    {
        // validation handled at controller level
        var dbMember = await _context.Members.FindAsync(id);
        if (dbMember == null || dbMember.Id != member.Id)
        {
            return false;
        }

        dbMember.FirstName = member.FirstName;
        dbMember.MiddleName = member.MiddleName;
        dbMember.LastName = member.LastName;

        return true;
    }

    public async Task<bool> DeleteMember(int id)
    {
        // validation handled at controller level
        var member = await _context.Members.FindAsync(id);
        if (member == null)
        {
            return false;
        }

        _context.Members.Remove(member);
        return true;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}