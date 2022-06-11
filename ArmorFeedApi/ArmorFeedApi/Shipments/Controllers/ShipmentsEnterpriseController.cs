﻿using System.Net.Mime;
using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Services;
using ArmorFeedApi.Shipments.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArmorFeedApi.Shipments.Controllers;

[ApiController]
[Route("/api/v1/enterprises/{enterpriseId}/shipments")]
[Produces(MediaTypeNames.Application.Json)]
public class ShipmentsEnterpriseController: ControllerBase
{
    private readonly IShipmentService _shipmentService;
    private readonly IMapper _mapper;


    public ShipmentsEnterpriseController(IShipmentService shipmentService, IMapper mapper)
    {
        _shipmentService = shipmentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ShipmentResource>> GetAllByEnterpriseId(int enterpriseId)
    {
        var shipments = await _shipmentService.ListByEnterpriseId(enterpriseId);
        var resources = _mapper.Map<IEnumerable<Shipment>, IEnumerable<ShipmentResource>>(shipments);
        return resources;
    }
}