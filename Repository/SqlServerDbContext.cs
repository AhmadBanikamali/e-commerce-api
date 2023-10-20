using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repository;

public class SqlServerDbContext : IdentityDbContext<ApplicationUser> 
{
}