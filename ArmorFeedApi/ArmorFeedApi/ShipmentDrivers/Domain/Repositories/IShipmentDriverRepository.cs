using ArmorFeedApi.Security.Domain.Respositories;

namespace ArmorFeedApi.ShipmentDrivers.Domain.Repositories;

public interface IShipmentDriverRepository : IUserRepository<ShipmentDriver.Domain.Models.ShipmentDriver>
{
    
}