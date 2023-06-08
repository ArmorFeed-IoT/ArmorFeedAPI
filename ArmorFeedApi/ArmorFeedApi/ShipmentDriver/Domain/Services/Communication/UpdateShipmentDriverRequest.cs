using System.ComponentModel.DataAnnotations;
using ArmorFeedApi.Security.Domain.Services.Communication;

namespace ArmorFeedApi.ShipmentDriver.Domain.Services.Communication;

public class UpdateShipmentDriverRequest : UpdateRequest
{
    [Required] public string LastName { get; set; }
}