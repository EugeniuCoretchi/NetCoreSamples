namespace AutoMapperSample.Models;

internal class Person
{
    public Guid Id { get; set; }
    public DateTime BirthDay { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public int DisplayName { get; set; }

    public Guid? DefaultAddress { get; set; }
    public ICollection<Address>? Addresses { get; set; }
    public ICollection<BankCard>? BankCards { get; set; }

    public bool AddCard(BankCard bankCard)
    {
        BankCards ??= new List<BankCard>();

        if (BankCards?.FirstOrDefault(x => x.Id == bankCard.Id) != default)
        {
            return false;
        }
        BankCards?.Add(bankCard);
        return true;
    }
}