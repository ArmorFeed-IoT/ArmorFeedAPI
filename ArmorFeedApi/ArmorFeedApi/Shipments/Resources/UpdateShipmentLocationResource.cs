using System.ComponentModel.DataAnnotations;

namespace ArmorFeedApi.Shipments.Resources
{
    public class UpdateShipmentLocationResource
    {
        [Required]
        public double CurrentLatitude { get; set; }
        [Required]
        public double CurrentLongitude { get; set; }
    }
}
