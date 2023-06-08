using ArmorFeedApi.ShipmentDrivers.Domain.Services.Communication;

namespace ArmorFeedApi.ShipmentDrivers.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<ShipmentDriver.Domain.Models.ShipmentDriver, AuthenticateShipmentDriverResponse>();
        CreateMap<ShipmentDriver.Domain.Models.ShipmentDriver, ShipmentDriverResponse>();
    }
}