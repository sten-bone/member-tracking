using MemberTracking.Data.Models;
using MemberTracking.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MemberTracking.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMemberRepository _membersRepository;

    public MemberController(IMemberRepository membersRepository)
    {
        _membersRepository = membersRepository;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<Member>>> GetAllMembers()
    {
        var members = await _membersRepository.GetAllMembers();
        return Ok(members);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Member>> GetMemberById(int id)
    {
        var member = await _membersRepository.GetMemberById(id);
        return Ok(member);
    }

    [HttpPost("")]
    public async Task<ActionResult> CreateMember([FromBody] Member member)
    {
        if (!Member.IsValid(member, requireId: false))
        {
            return BadRequest("Invalid member.");
        }

        await _membersRepository.CreateMember(member);
        await _membersRepository.SaveChanges();
        return Ok();
    }

    [HttpPost("{id:int}")]
    public async Task<ActionResult<bool>> UpdateMember(int id, [FromBody] Member member)
    {
        if (!Member.IsValid(member))
        {
            return BadRequest("Invalid member.");
        }

        var result = await _membersRepository.UpdateMember(id, member);
        await _membersRepository.SaveChanges();
        return result;
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteMember(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid Member ID provided.");
        }

        var result = await _membersRepository.DeleteMember(id);
        await _membersRepository.SaveChanges();
        return result;
    }
}