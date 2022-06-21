using MemberTracking.Data.DbContext;
using MemberTracking.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var allowLocalhostRequests = "_allowLocalhostRequests";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MemberDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:MemberDB"));
});

builder.Services.AddScoped<IMemberRepository, MembersRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowLocalhostRequests,
        policy =>
        {
            policy.WithOrigins("https://localhost:44389", 
                "https://localhost:44489")
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors(allowLocalhostRequests);

app.UseAuthorization();
app.MapControllers();

app.Run();
