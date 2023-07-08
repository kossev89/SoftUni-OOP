namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> accounts = new();
            foreach (var item in input)
            {
                string[] accountInfo = item
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);
                accounts.Add(int.Parse(accountInfo[0]), double.Parse(accountInfo[1]));
            }
            //accounts[1]++;


            string[] commandInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commandInfo[0] != "End")
            {
                int accountNumber = int.Parse(commandInfo[1]);
                double moneyStream = double.Parse(commandInfo[2]);
                switch (commandInfo[0])
                {
                    case "Deposit":
                        try
                        {
                            if (accounts.ContainsKey(accountNumber))
                            {

                                accounts[accountNumber] += moneyStream;
                                var currentAccount = accounts.FirstOrDefault(x => x.Key == accountNumber);
                                Console.WriteLine($"Account {currentAccount.Key} has new balance: {currentAccount.Value:f2}");
                            }
                            else
                            {
                                throw new ArgumentException("Invalid account!");
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "Withdraw":
                        try
                        {
                            if (accounts.ContainsKey(accountNumber))
                            {
                                if (accounts[accountNumber] > moneyStream)
                                {
                                    accounts[accountNumber] -= moneyStream;
                                    var currentAccount = accounts.FirstOrDefault(x => x.Key == accountNumber);
                                    Console.WriteLine($"Account {currentAccount.Key} has new balance: {currentAccount.Value:f2}");
                                }
                                else
                                {
                                    throw new ArgumentException("Insufficient balance!");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Invalid account!");
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
                Console.WriteLine("Enter another command");
                commandInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}