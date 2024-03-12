using AutoMapperSample;
using AutoMapperSample.Models;
using AutoMapperSample.ViewModel;

var terminal = new TerminalApp();

var mapper = Manager.CreateMapper();
var bank = Manager.CreateNewBank("McGeeComBank", "");
var person = Manager.CreateNewPerson();
var card = Manager.CreateNewBankCard(bank.Id);

person.AddCard(card);

var viewModel = mapper.Map<PersonViewModel>(person);

terminal.Print(bank);
terminal.Print(card);
terminal.Print(viewModel);