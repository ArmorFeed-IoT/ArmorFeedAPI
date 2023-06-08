using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Services;
using ArmorFeedApi.Shipments.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArmorFeedApi.Shipments.Controllers
{
    public class ShipementsDriverController: ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        private readonly IMapper _mapper;

        public ShipementsDriverController(IShipmentService shipmentService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/v1/shipment-drivers/{shipmentDriverId}/shipments")]
        public async Task<IEnumerable<ShipmentResource>> GetAllByShipmentDriverId(int shipmentDriverId)
        {
            var shipments = await _shipmentService.ListByShipmentDriverId(shipmentDriverId);
            var resources = _mapper.Map<IEnumerable<Shipment>, IEnumerable<ShipmentResource>>(shipments);
            return resources;
        }
    }
}
