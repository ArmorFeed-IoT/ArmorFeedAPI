using ArmorFeedApi.Shared.Domain.Repositories;
using ArmorFeedApi.ShipmentDriver.Domain.Models;
using ArmorFeedApi.ShipmentDrivers.Domain.Repositories;
using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Repositories;
using ArmorFeedApi.Shipments.Domain.Services;
using ArmorFeedApi.Shipments.Domain.Services.Communications;
using ArmorFeedApi.Shipments.Resources;

namespace ArmorFeedApi.Shipments.Services;

public class ShipmentService: IShipmentService
{
    private readonly IShipmentRepository _shipmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IShipmentDriverRepository _shipmentDriverRepository;

    public ShipmentService(IShipmentRepository shipmentRepository, IUnitOfWork unitOfWork, IShipmentDriverRepository shipmentDriverRepository)
    {
        _shipmentRepository = shipmentRepository;
        _unitOfWork = unitOfWork;
        _shipmentDriverRepository = shipmentDriverRepository;
    }

    public async Task<IEnumerable<Shipment>> ListAsync()
    {
        return await _shipmentRepository.ListAsync();
    }

    public async Task<Shipment> GetByIdAsync(int id)
    {
        return await _shipmentRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<Shipment>> ListByEnterpriseId(int enterpriseId)
    {
        return await _shipmentRepository.FindByEnterpriseId(enterpriseId);
    }

    public async Task<IEnumerable<Shipment>> ListByCustomerId(int customerId)
    {
        return await _shipmentRepository.FindByCustomerId(customerId);
    }
    public async Task<IEnumerable<Shipment>> ListByShipmentDriverId(int shipmentDriverId)
    {
        return await _shipmentRepository.FindByShipmentDriverId(shipmentDriverId);
    }

    public async Task<ShipmentResponse> SaveAsync(Shipment shipment)
    {
        try
        {
            await _shipmentRepository.AddAsync(shipment);
            await _unitOfWork.CompleteAsync();

            return new ShipmentResponse(shipment);
        }
        catch (Exception e)
        {
            return new ShipmentResponse($"An error occurred while saving the shipment: {e.Message}");
        }
    }

    public async Task<ShipmentResponse> UpdateAsync(int id, Shipment shipment)
    {
        var existingShipment = await _shipmentRepository.FindByIdAsync(id);

        if (existingShipment == null)
            return new ShipmentResponse("Shipment not found");

        ShipmentDriver.Domain.Models.ShipmentDriver? driver = null;
        if (shipment.ShipmentDriverId.HasValue)
        {
            var existingShipmentDriver = await _shipmentDriverRepository.FindByIdAsync(shipment.ShipmentDriverId.Value);
            if (existingShipmentDriver == null)
                return new ShipmentResponse($"Shipment Driver with id {shipment.ShipmentDriverId.Value} not found");
            driver = existingShipmentDriver;
        }

        existingShipment.DeliveryDate = shipment.DeliveryDate;
        existingShipment.Status = shipment.Status;
        existingShipment.ShipmentDriverId = shipment.ShipmentDriverId;
        existingShipment.ShipmentDriver = driver;
        try
        {
            _shipmentRepository.Update(existingShipment);
            await _unitOfWork.CompleteAsync();

            return new ShipmentResponse(existingShipment);
        }
        catch (Exception e)
        {
            return new ShipmentResponse($"An error occurred while updating the shipment: {e.Message}");
        }
    }

    public async Task<ShipmentResponse> DeleteAsync(int id)
    {
        var existingShipment = await _shipmentRepository.FindByIdAsync(id);

        if (existingShipment == null)
            return new ShipmentResponse("Shipment not found");
        try
        {
            _shipmentRepository.Remove(existingShipment);
            await _unitOfWork.CompleteAsync();
            return new ShipmentResponse(existingShipment);
        }
        catch (Exception e)
        {
            return new ShipmentResponse($"An error occurred while deleting the shipment: {e.Message}");
        }
    }

    public async Task<ShipmentResponse> UpdateLocationAsync(int id, UpdateShipmentLocationResource updateShipmentLocationResource)
    {
        var existingShipment = await _shipmentRepository.FindByIdAsync(id);

        if (existingShipment == null)
            return new ShipmentResponse("Shipment not found");

        existingShipment.CurrentLatitude = updateShipmentLocationResource.CurrentLatitude;
        existingShipment.CurrentLongitude = updateShipmentLocationResource.CurrentLongitude;

        try
        {
            _shipmentRepository.Update(existingShipment);
            await _unitOfWork.CompleteAsync();

            return new ShipmentResponse(existingShipment);
        }
        catch (Exception e)
        {
            return new ShipmentResponse($"An error occurred while updating the shipment: {e.Message}");
        }
    }

    public async Task<IEnumerable<Shipment>> ListShipmentWthoutShipmentDriverAsync(int enterpriseId)
    {
        return await _shipmentRepository.FindShipmentsWithoutShipmentDriverAsync(enterpriseId);
    }
}