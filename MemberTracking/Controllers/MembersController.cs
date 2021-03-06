using MemberTracking.Data.Models;
using MemberTracking.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MemberTracking.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IMemberRepository _membersRepository;

    public MembersController(IMemberRepository membersRepository)
    {
        _membersRepository = membersRepository;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<Member>>> GetAllMembersAsync([FromQuery] string sortBy, [FromQuery] string orderBy)
    {
        var members = await _membersRepository.GetAllMembers();
        // no sorting requested
        if (orderBy == "default")
        {
            return Ok(members);
        }

        // sort depending on if query is ascending or descending
        return (orderBy == "asc" ?
            members.OrderBy(x =>
            {
                return sortBy switch
                {
                    "first" => x.FirstName,
                    "middle" => x.MiddleName,
                    _ => x.LastName
                };
            }) :
            members.OrderByDescending(x =>
            {
                return sortBy switch
                {
                    "first" => x.FirstName,
                    "middle" => x.MiddleName,
                    _ => x.LastName
                };
            })).ToList();
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Member>> GetMemberByIdAsync(int id)
    {
        var member = await _membersRepository.GetMemberById(id);
        return Ok(member);
    }

    [HttpPost("")]
    public async Task<ActionResult<bool>> CreateMemberAsync([FromBody] Member member)
    {
        if (!Member.IsValid(member, requireId: false))
        {
            return BadRequest("Invalid member.");
        }

        var result = await _membersRepository.CreateMember(member);
        await _membersRepository.SaveChanges();
        return Ok(result);
    }

    [HttpPost("{id:int}")]
    public async Task<ActionResult<bool>> UpdateMemberAsync(int id, [FromBody] Member member)
    {
        if (!Member.IsValid(member))
        {
            return BadRequest("Invalid member.");
        }

        var result = await _membersRepository.UpdateMember(id, member);
        await _membersRepository.SaveChanges();
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteMemberAsync(int id)
    {
        var result = await _membersRepository.DeleteMember(id);
        await _membersRepository.SaveChanges();
        return Ok(result);
    }
}