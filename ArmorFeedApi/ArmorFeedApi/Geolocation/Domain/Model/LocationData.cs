using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Models;

namespace ArmorFeedApi.Geolocation.Domain.Model
{
    public class LocationData
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Height { get; set; }
        public Enterprise Enterprise { get; set; }
        public int EnterpriseId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
