namespace MemberTracking.Data.Models;

public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public static bool IsValid(Member member, bool requireId = true)
    {
        if (!new[] { member.FirstName, member.LastName, member.MiddleName }
                .All(x => x.Length < 30))
        {
            return false;
        }

        if (requireId && member.Id <= 0)
        {
            return false;
        }

        return true;
    }
}