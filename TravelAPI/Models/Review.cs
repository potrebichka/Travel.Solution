namespace TravelAPI.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Description {get;set;}
        public double Rating {get;set;}
        public Destination Destination {get;set;}
        public int DestinationId {get;set;}
        public string user_name {get;set;}
    }
}