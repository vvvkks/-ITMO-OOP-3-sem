using System.Diagnostics;
using Banks.Entities.Accounts;
using Banks.Entities.Banks;
using Banks.Entities.Clients;

namespace Banks.Console;

public static class Console
{
    public static void PrintPossibleCommands()
    {
        System.Console.WriteLine("Choose your priority: 1) bank owner ; 2) client");
        string? answer = System.Console.ReadLine();
        switch (answer)
        {
            case "1":
                BankOwnerAnswer();
                break;
            case "2":
                ClientAnswer();
                break;
        }
    }

    public static void BankOwnerAnswer()
    {
        var commandArray = new[] { "Add Bank", "Exit" };
        var commandList = new List<string>(commandArray);
        System.Console.WriteLine("Possible commands: ");
        for (int i = 0; i < commandList.Count; i++)
        {
            System.Console.WriteLine((i + 1) + "." + commandList[i]);
        }

        System.Console.WriteLine();
        MenuForBankOwner();
    }

    public static void MenuForBankOwner()
    {
        string? command = System.Console.ReadLine();
        switch (command)
        {
            case "Add Bank":
                System.Console.WriteLine("Bank name:");
                var centralBank = new CentralBank("Central Bank");
                string? bankName = System.Console.ReadLine();
                System.Console.WriteLine("Commission Percent:");
                decimal commisiomPercent = Convert.ToDecimal(System.Console.ReadLine());
                System.Console.WriteLine("Credit Limit:");
                decimal creditLimit = Convert.ToDecimal(System.Console.ReadLine());
                System.Console.WriteLine("Pay Percent:");
                decimal payPercent = Convert.ToDecimal(System.Console.ReadLine());
                Debug.Assert(bankName != null, nameof(bankName) + " != null");
                centralBank.CreateBank(bankName, commisiomPercent, creditLimit, payPercent);
                System.Console.WriteLine("Bank created:");
                break;
            case "Exit":
                return;
        }
    }

    public static void ClientAnswer()
    {
        string[] commandArray = new[] { "Add client", "Add account", "Exit" };
        var commandList = new List<string>(commandArray);
        System.Console.WriteLine("Possible commands: ");
        for (int i = 0; i < commandList.Count; i++)
        {
            System.Console.WriteLine((i + 1) + "." + commandList[i]);
        }

        System.Console.WriteLine();
        MenuForClient();
    }

    public static void MenuForClient()
    {
        string? command = System.Console.ReadLine();
        switch (command)
        {
            case "Add client":
                System.Console.WriteLine(" Enter your name: ");
                string? name = System.Console.ReadLine();
                System.Console.WriteLine(" Enter your surname: ");
                string? surname = System.Console.ReadLine();
                System.Console.WriteLine(" Enter your passport: ");
                string? passport = System.Console.ReadLine();
                System.Console.WriteLine(" Enter your address: ");
                string? address = System.Console.ReadLine();
                if (name != null && surname != null && passport != null && address != null)
                {
                    Client.ClientBuilder clientBuilder = new Client.ClientBuilder();
                    clientBuilder.Build();
                    System.Console.WriteLine(" You have been successfully added! ");
                }
                else
                {
                    System.Console.WriteLine(" Please, fill all gaps for verified profile ");
                }

                break;
            case "Add account":
                System.Console.WriteLine(" What type account you want?  1) credit ; 2) debit ; 3) deposit");
                string? answer = System.Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        AddCreditAccount();
                        break;
                    case "2":
                        AddDebitAccount();
                        break;
                    case "3":
                        AddDepositAccount();
                        break;
                }

                void AddCreditAccount()
                {
                    var centralBank = new CentralBank("Central Bank");
                    Bank bank1 = centralBank.CreateBank("bankName", 10, 500000, 10);
                    System.Console.WriteLine(" Enter your name: ");
                    string? name = System.Console.ReadLine();
                    System.Console.WriteLine(" Enter your surname: ");
                    string? surname = System.Console.ReadLine();
                    System.Console.WriteLine(" Enter your passport: ");
                    string? passport = System.Console.ReadLine();
                    System.Console.WriteLine(" Enter your address: ");
                    string? address = System.Console.ReadLine();
                    if (name != null && surname != null && passport != null && address != null)
                    {
                        Client.ClientBuilder clientBuilder = new Client.ClientBuilder();
                        clientBuilder.Build();
                        System.Console.WriteLine(" Enter your balance:  ");
                        decimal balance = Convert.ToDecimal(System.Console.ReadLine());
                        bank1.OpenCreditAccount(clientBuilder.Build(), balance, bank1);
                        System.Console.WriteLine(" Your account has been successfully created! ");
                    }
                }

                void AddDebitAccount()
                {
                    var centralBank = new CentralBank("Central Bank");
                    Bank bank1 = centralBank.CreateBank("bankName", 10, 500000, 10);
                    System.Console.WriteLine(" Enter your name: ");
                    string? name = System.Console.ReadLine();
                    System.Console.WriteLine(" Enter your surname: ");
                    string? surname = System.Console.ReadLine();
                    System.Console.WriteLine(" Enter your passport: ");
                    string? passport = System.Console.ReadLine();
                    System.Console.WriteLine(" Enter your address: ");
                    string? address = System.Console.ReadLine();
                    if (name != null && surname != null && passport != null && address != null)
                    {
                        Client.ClientBuilder clientBuilder = new Client.ClientBuilder();
                        clientBuilder.Build();
                        System.Console.WriteLine(" Enter your balance:  ");
                        decimal balance = Convert.ToDecimal(System.Console.ReadLine());
                        bank1.OpenDebitAccount(clientBuilder.Build(), balance, bank1);
                        System.Console.WriteLine(" Your account has been successfully created! ");
                    }
                }

                void AddDepositAccount()
                {
                    var centralBank = new CentralBank("Central Bank");
                    Bank bank1 = centralBank.CreateBank("bankName", 10, 500000, 10);
                    System.Console.WriteLine(" Enter your name: ");
                    string? name = System.Console.ReadLine();
                    System.Console.WriteLine(" Enter your surname: ");
                    string? surname = System.Console.ReadLine();
                    System.Console.WriteLine(" Enter your passport: ");
                    string? passport = System.Console.ReadLine();
                    System.Console.WriteLine(" Enter your address: ");
                    string? address = System.Console.ReadLine();
                    if (name != null && surname != null && passport != null && address != null)
                    {
                        Client.ClientBuilder clientBuilder = new Client.ClientBuilder();
                        clientBuilder.Build();
                        System.Console.WriteLine(" Enter your balance:  ");
                        decimal balance = Convert.ToDecimal(System.Console.ReadLine());
                        System.Console.WriteLine(" Enter time for your money:  ");
                        int time = (int)Convert.ToInt64(System.Console.ReadLine());
                        bank1.AddDepositAccount(clientBuilder.Build(), balance, bank1, time);
                        System.Console.WriteLine(" Your account has been successfully created! ");
                    }
                }

                break;

            case "Exit":
                return;
        }
    }
}