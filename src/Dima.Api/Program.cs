using Dima.Api.Data;
using Dima.Api.Endpoints;
using Dima.Api.Handlers;
using Dima.Api.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
	.AddIdentityCore<AppUser>(options =>
	{
		options.Password.RequiredLength = 10;
		options.Password.RequireDigit = true;
		options.Password.RequireLowercase = true;
		options.Password.RequireUppercase = true;
		options.Password.RequireNonAlphanumeric = true;
	})
	.AddRoles<IdentityRole<long>>()
	.AddEntityFrameworkStores<AppDbContext>()
	.AddDefaultTokenProviders()
	.AddApiEndpoints();

builder.Services.AddScoped<ICategoryHandler, CategoryHandler>();
builder.Services.AddScoped<ITransactionHandler, TransactionHandler>();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
	.AddIdentityCookies();
		
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (builder.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "Dima Api"));
}

app.MapGet("/welcome", () => new { message = "Welcome to Dima API!" });

app.MapEndpoints();

app.MapGroup("v1/identity")
	.WithTags("Identity")
	.MapIdentityApi<AppUser>();

app.MapGroup("v1/identity")
	.WithTags("Identity")
	.MapGet("/roles", async (UserManager<AppUser> userManager, HttpContext httpContext) =>
	{
		var user = await userManager.GetUserAsync(httpContext.User);
		if (user == null)
			return Results.Unauthorized();

		var roles = await userManager.GetRolesAsync(user);
		return Results.Ok(roles);
	})
	.RequireAuthorization();

app.MapGroup("v1/identity")
	.WithTags("Identity")
	.MapPost("/logout", async (SignInManager<AppUser> signInManager) =>
	{
		await signInManager.SignOutAsync();
		return Results.NoContent();
	})
	.RequireAuthorization();

app.Run();