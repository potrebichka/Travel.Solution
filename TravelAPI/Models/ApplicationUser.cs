using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace TravelAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Reviews = new HashSet<Review>();
        }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}