namespace AutoMapperSample.ViewModel;

internal class PersonViewModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public DateOnly BirthDay { get; set; }

    public int AddressesCount { get; set; }

    public int BankCardsCount { get; set; }

}