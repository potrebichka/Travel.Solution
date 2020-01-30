using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TravelMVC.Models
{
    public class TravelMVCContext : IdentityDbContext<ApplicationUser>
    {
        public TravelMVCContext(DbContextOptions options) : base(options) {}
    }
}