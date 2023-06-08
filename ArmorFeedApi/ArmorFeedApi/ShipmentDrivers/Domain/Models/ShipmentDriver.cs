using ArmorFeedApi.Security.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Models;

namespace ArmorFeedApi.ShipmentDriver.Domain.Models;

public class ShipmentDriver : User
{
    public IList<Shipment> Shipments { get; set; }
}