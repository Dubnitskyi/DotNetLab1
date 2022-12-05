namespace CashMachineConsoleApp
{
    static class MenuElements
    {
        public static void DisplayAuthentication(out string userCardNumber, out int userPinCode)
        {
            Console.Clear();
            Console.WriteLine("Authentication");
            Console.Write("  Enter the card number in the format (nnnn-nnnn-nnnn-nnnn): ");
            userCardNumber = Console.ReadLine();
            Console.Write("  Enter pin code: ");
            userPinCode = EnterData.GetNumber();
        }

        public static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Simulation of ATM operation");
            Console.WriteLine("  1) Authentication");
            Console.WriteLine("  0) Output");
            Console.Write("\nChoose one of the points: ");
        }

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose one of the points:");
            Console.WriteLine("  1) Viewing the balance on the card");
            Console.WriteLine("  2) Withdrawal of funds");
            Console.WriteLine("  3) Transfer of funds to the card");
            Console.WriteLine("  4) Transfer of funds");
            Console.WriteLine("  0) Output");
            Console.Write("\n Your choice: ");
        }

        public static void ShowBalance()
        {
            Console.Clear();
            Console.WriteLine("Viewing the balance on the card");
        }

        public static void TakeCash(out int money)
        {
            Console.Clear();
            Console.WriteLine("Withdrawal of funds");
            Console.Write($"  Enter the amount to withdraw: ");
            money = EnterData.GetNumber();
        }

        public static void AddMoney(out int money)
        {
            Console.Clear();
            Console.WriteLine("Transfer of funds to the card");
            Console.Write($"  Enter the amount to enroll: ");
            money = EnterData.GetNumber();
        }

        public static void MoneyTransfer(out string userCardNumber, out int money)
        {
            Console.Clear();
            Console.WriteLine("Перерахування коштiв");
            Console.Write($"  Transfer to card number: ");
            userCardNumber = Console.ReadLine();
            Console.Write($" Enter the amount to transfer: ");
            money = EnterData.GetNumber();
        }
    }
}
