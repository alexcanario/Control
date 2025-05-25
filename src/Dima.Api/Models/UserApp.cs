using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Models;

public class UserApp : IdentityUser<long>
{
	public IList<IdentityRole<long>>? Roles { get; set; } = [];
}