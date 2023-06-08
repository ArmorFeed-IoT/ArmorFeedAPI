using ArmorFeedApi.Customers.Domain.Services.Communication;
using ArmorFeedApi.Security.Domain.Services.Communication;
using ArmorFeedApi.ShipmentDriver.Domain.Services.Communication;

namespace ArmorFeedApi.ShipmentDriver.Domain.Services;

public interface IShipmentDriverService
{
    Task<AuthenticateShipmentDriverResponse> Authenticate(AuthenticateRequest request);
    Task RegisterAsync(RegisterShipmentDriverRequest request);
    Task UpdateAsync(int id, UpdateSh request);
}