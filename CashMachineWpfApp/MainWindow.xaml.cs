using System;
using System.Windows;
using System.Windows.Controls;
using CashMachineClassLibrary;

namespace CashMachineWpfApp
{
    public partial class MainWindow : Window
    {
        Bank _bank;
        AutomatedTellerMachine _cashMachine;
        Account _currentUser;

        public MainWindow()
        {
            InitializeComponent();

            Bank bank = new Bank("Monobank");
            _bank = bank;

            Account account1 = new Account("1111-1111-1111-1111", 1111, "Ivan", "Ivanov", 2000);
            bank.AddUser(account1);

            Account account2 = new Account("2222-2222-2222-2222", 2222, "Petro", "Petrosan", 1000);
            bank.AddUser(account2);

            AutomatedTellerMachine cashMachine = new AutomatedTellerMachine(150000, 1010, "Київська 48");
            _cashMachine = cashMachine;
            bank.AddCashMachine(cashMachine);

            void PrintMessage(string message) => MessageBox.Show(message);
            cashMachine.RegisterHandler(PrintMessage);
            
            MainMenu.Visibility = Visibility.Visible;
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            string userChoice = (sender as Button).Name;
            if(userChoice == "AuthenticationButton")
            {
                MainMenu.Visibility = Visibility.Hidden;
                Authentication.Visibility = Visibility.Visible;
            }
            else Environment.Exit(0);
        }

        private void AuthenticationButton_Click(object sender, RoutedEventArgs e)
        {
            string userChoice = (sender as Button).Name;
            if (userChoice == "NextButton")
            {
                int userPinCode = GetNumber(PinCodePasswordBox.Password);
                string userCardNumber = CardNumberTextBox.Text;

                _currentUser = _bank.Authentication(userCardNumber, userPinCode);

                if (_currentUser == null)
                    MessageBox.Show("Невiрнi данi.");
                else
                {
                    Authentication.Visibility = Visibility.Hidden;
                    CardNumberTextBox.Text = "";
                    PinCodePasswordBox.Password = "";
                    Menu.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MainMenu.Visibility = Visibility.Visible;
                Authentication.Visibility = Visibility.Hidden;
                CardNumberTextBox.Text = "";
                PinCodePasswordBox.Password = "";
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            string userChoice = (sender as Button).Name;
            switch (userChoice)
            {
                case "ShowBalanceMenuButton":
                    _cashMachine.ShowBalance(_currentUser);
                    break;
                case "TakeCashMenuButton":
                    TakeCash.Visibility = Visibility.Visible;
                    Menu.Visibility = Visibility.Hidden;
                    break;
                case "AddMoneyMenuButton":
                    AddMoney.Visibility = Visibility.Visible;
                    Menu.Visibility = Visibility.Hidden;
                    break;
                case "MoneyTransferMenuButton":
                    MoneyTransfer.Visibility = Visibility.Visible;
                    Menu.Visibility = Visibility.Hidden;
                    break;
                default:
                    Menu.Visibility = Visibility.Hidden;
                    MainMenu.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void TakeCashButton_Click(object sender, RoutedEventArgs e)
        {
            int money = GetNumber(TakeCashTextBox.Text);
            TakeCash.Visibility = Visibility.Hidden;
            Menu.Visibility = Visibility.Visible;
            TakeCashTextBox.Text = "";
            _cashMachine.TakeCash(_currentUser, money);
        }

        private void AddMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            int money = GetNumber(AddMoneyTextBox.Text);
            AddMoney.Visibility = Visibility.Hidden;
            Menu.Visibility = Visibility.Visible;
            AddMoneyTextBox.Text = "";
            _cashMachine.AddMoney(_currentUser, money);
        }

        private void MoneyTransferButton_Click(object sender, RoutedEventArgs e)
        {
            int money = GetNumber(MoneyTextBox.Text);
            string userCardNumber =UserCardNumberTextBox.Text;
            MoneyTransfer.Visibility = Visibility.Hidden;
            Menu.Visibility = Visibility.Visible;
            UserCardNumberTextBox.Text = "";
            MoneyTextBox.Text = "";
            _cashMachine.MoneyTransfer(_bank, _currentUser, userCardNumber, money);
        }

        public static int GetNumber(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return 0;
            }
        }
    }
}
