namespace CashMachineClassLibrary
{
    public delegate void AutomatedTellerMachineHandler(string message);

    public class AutomatedTellerMachine
    {
        int Cash { set; get; }
        int CashMachineId { set; get; }
        string Address { set; get; }

        public AutomatedTellerMachine(int cash, int cashMachineId, string address)
        {
            this.Cash = cash;
            this.CashMachineId = cashMachineId;
            this.Address = address;
        }

        AutomatedTellerMachineHandler? action;

        public void RegisterHandler(AutomatedTellerMachineHandler del)
        {
            action = del;
        }

        public void UnregisterHandler(AutomatedTellerMachineHandler del)
        {
            action -= del;
        }

        public void ShowBalance(Account account)
        {
            action?.Invoke($"\nBalans: {account.Balance} UAH.");
        }

        public void AddMoney(Account account, int money)
        {
            account.Balance += money;
            Cash += money;
            action?.Invoke($"\nYour account has been credited {money} UAH.");
        }

        public void TakeCash(Account account, int money)
        {
            if(Cash < money)
            {
                action?.Invoke($"\nThere are not enough funds in the ATM.");
                return;
            }
            if (account.Balance >= money)
            {
                account.Balance -= money;
                Cash -= money;
                action?.Invoke($"\nIt was withdrawn from the account{money} UAH.");
            }
            else
            {
                action?.Invoke($"\nInsufficient funds. Balance: {account.Balance} UAH.");
            }
        }

        public void MoneyTransfer(Bank bank, Account sender, string recipientCardNumber, int money)
        {
            foreach (Account user in bank.Users)
            {
                if (user.CardNumber == recipientCardNumber)
                {
                    if (sender.Balance >= money)
                    {
                        sender.Balance -= money;
                        user.Balance += money;
                        action?.Invoke($"\nIt was listed {money} UAH.");
                    }
                    else
                    {
                        action?.Invoke($"\nInsufficient funds. Balance: {sender.Balance} UAH.");
                    }
                    return;
                }
            }
            action?.Invoke("\nRecipient's card number is invalid.");
        }
    }
}
