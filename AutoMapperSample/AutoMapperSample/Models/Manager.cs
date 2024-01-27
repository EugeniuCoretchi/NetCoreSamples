using AutoMapper;
using AutoMapperSample.Profiles;

namespace AutoMapperSample.Models;

internal static class Manager
{
    public static Person CreateNewPerson()
    {
        var person = new Person()
        {
            Id = Guid.NewGuid(),
            FirstName = "DefaultName",
            LastName = "DefaultName",
            BirthDay = DateTime.Parse("1982/01/16 12:00:00")
        };
        return person;
    }

    public static BankCard CreateNewBankCard(Guid bankId)
    {
        var bankCard = new BankCard()
        {
            Id = Guid.NewGuid(),
            Type = BankCardType.Credit,
            BankId = bankId,
            Number = "0000-0000-0000-0000",
            ValidFor = DateTime.Parse("2030/01/01 12:00:00"),
            Name = "Cortny Cox",
        };
        return bankCard;
    }

    public static Bank CreateNewBank(string name, string description)
    {
        var bank = new Bank()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };
        return bank;
    }

    public static IMapper CreateMapper()
    {
        var mapperConfiguration = new MapperConfiguration(x =>
        {
            x.AddProfile<PersonMapperProfile>();
        });

        mapperConfiguration.AssertConfigurationIsValid();

        return mapperConfiguration.CreateMapper();
    }
}