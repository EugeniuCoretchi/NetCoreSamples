namespace AutoMapperSample.Models;

internal class BankCard
{
    public Guid Id { get; set; }

    public BankCardType Type { get; set; }

    public string Name { get; set; }

    public string Number { get; set; }

    public DateTime ValidFor { get; set; }

    public string Description { get; set; }

    public Guid BankId { get; set; }
}

