using MemberTracking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemberTracking.Data.DbContext.EntityTypeConfigurations;

public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>  
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.FirstName);
        builder.Property(x => x.MiddleName);
        builder.Property(x => x.LastName);

        /* Uncomment to edit seed data
        builder.HasData(new Member
        {
            Id = 1,
            FirstName = "Kara",
            MiddleName = "Percival",
            LastName = "Sullivan"
        }, new Member
        {
            Id = 2,
            FirstName = "Stephen",
            MiddleName = "Maxwell",
            LastName = "Hollinden"
        }, new Member
        {
            Id = 3,
            FirstName = "Caldwell",
            MiddleName = "Cooper",
            LastName = "Crawford"
        }, new Member
        {
            Id = 4,
            FirstName = "Mary",
            MiddleName = "Sue",
            LastName = "Richter"
        }, new Member
        {
            Id = 5,
            FirstName = "Elisabeth",
            MiddleName = "Walder",
            LastName = "Scott"
        }, new Member
        {
            Id = 6,
            FirstName = "Michael",
            LastName = "Charles",
            MiddleName = "Utrauer"
        }, new Member
        {
            Id = 7,
            FirstName = "Charlotte",
            MiddleName = "Alice",
            LastName = "Wilson"
        }, new Member
        {
            Id = 8,
            FirstName = "James",
            MiddleName = "Edward",
            LastName = "Anderson"
        }, new Member
        {
            Id = 9,
            FirstName = "Ahmed",
            MiddleName = "Yan",
            LastName = "Kumar"
        }, new Member
        {
            Id = 10,
            FirstName = "Nushi",
            MiddleName = "Li",
            LastName = "Huang"
        });
        */
    }
}