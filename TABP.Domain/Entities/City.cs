﻿namespace TABP.Domain.Entities;

public class City : AuditableEntity
{
    public Guid CityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ThumbnailImage { get; set; }
    public string PostalCode { get; set; }
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
    public List<Hotel> Hotels { get; set; }
}