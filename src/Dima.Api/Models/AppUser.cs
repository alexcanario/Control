using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Models;

public class AppUser : IdentityUser<long>
{
	public IList<IdentityRole<long>>? Roles { get; set; } = [];
}