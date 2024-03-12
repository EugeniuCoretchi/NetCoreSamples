namespace AutoMapperSample.Models;

internal class Address
{
    public Guid Id { get; set; }

    public string Country { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Building { get; set; }
    public string PostalCode { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
}