using System.Collections.Generic;
namespace TravelMVC.Models
{
    public class Destination
    {
        public Destination()
        {
            this.Reviews = new HashSet<Review>();
        }
        public int DestinationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public double Rating {get;set;}
        public virtual ICollection<Review> Reviews { get; set;}
    }
}