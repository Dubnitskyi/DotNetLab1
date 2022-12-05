namespace CashMachineConsoleApp
{
    public static class EnterData
    {
        public static int GetChoice()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nInvalid data entered.");
                return 0;
            }
        }

        public static int GetNumber()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }
    }
}
