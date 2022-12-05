using CashMachineClassLibrary;
using CashMachineConsoleApp;
using System.Runtime.CompilerServices;


Bank bank = new Bank("Monobank");

Account account1 = new Account("1111-1111-1111-1111", 1111, "Ivan", "Ivanov", 2000);
bank.AddUser(account1);

Account account2 = new Account("2222-2222-2222-2222", 2222, "Petro", "Petrosan", 1000);
bank.AddUser(account2);

AutomatedTellerMachine cashMachine = new AutomatedTellerMachine(150000, 1010, "Київська 48");
bank.AddCashMachine(cashMachine);

void PrintMessage(string message) => Console.WriteLine(message);
cashMachine.RegisterHandler(PrintMessage);

int userChoice;

do
{
    MenuElements.DisplayMainMenu();
    userChoice = EnterData.GetChoice();
    if (userChoice != 1)
        break;

    int userPinCode;
    string userCardNumber;
    MenuElements.DisplayAuthentication(out userCardNumber, out userPinCode);
    Account currentUser = bank.Authentication(userCardNumber, userPinCode);
    if(currentUser == null)
    {
        Console.WriteLine("\nIncorrect data.");
        Console.Write("\n Press Enter to return to the menu");
        Console.ReadLine();
        continue;
    }

    do
    {
        MenuElements.DisplayMenu();
        userChoice = EnterData.GetChoice();
        int money = 0;

        switch (userChoice)
        {
            case 1:
                MenuElements.ShowBalance();
                cashMachine.ShowBalance(currentUser);
                break;
            case 2:
                MenuElements.TakeCash(out money);
                cashMachine.TakeCash(currentUser, money);
                break;
            case 3:
                MenuElements.AddMoney(out money);
                cashMachine.AddMoney(currentUser, money);
                break;
            case 4:
                MenuElements.MoneyTransfer(out userCardNumber, out money);
                cashMachine.MoneyTransfer(bank, currentUser, userCardNumber, money);
                break;
            default:
                userChoice = 0;
                break;
        }

        if (userChoice != 0)
        {
            Console.Write("\nPress Enter to return to the menu");
            Console.ReadLine();
        }
    } while (userChoice != 0);

    userChoice = 1;

} while(userChoice != 0);
