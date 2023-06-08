using System.ComponentModel.DataAnnotations;
using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.ShipmentDriver.Domain.Services.Communication;

public class RegisterShipmentDriverRequest : RegisterRequest
{
    [Required] public string LastName { get; set; }
}