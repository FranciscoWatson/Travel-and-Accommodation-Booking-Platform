﻿namespace TABP.Domain.Entities;

public class City
{
    public Guid CityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
}