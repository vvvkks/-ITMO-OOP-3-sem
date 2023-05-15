using Banks.Entities.Accounts;
using Banks.Entities.Clients;

namespace Banks.Entities.Banks;

public class Bank
{
    private List<Client> _clients;
    private List<DebitAccount> _debitAccounts;
    private List<CreditAccount> _creditAccounts;
    private List<DepositAccount> _depositAccounts;
    private List<Bank> _banks;

    public Bank(string name, decimal comissionPercent, decimal creditLimit, decimal payPercent)
    {
        Name = name;
        ComissionPercent = comissionPercent;
        CreditLimit = creditLimit;
        PayPercent = payPercent;
        Id = Guid.NewGuid();
        _banks = new List<Bank>();
        _clients = new List<Client>();
        _debitAccounts = new List<DebitAccount>();
        _creditAccounts = new List<CreditAccount>();
        _depositAccounts = new List<DepositAccount>();
    }

    public string Name { get; set; }
    public decimal ComissionPercent { get; }
    public decimal CreditLimit { get; }
    public decimal PayPercent { get; set; }
    public Guid Id { get; }

    public DebitAccount OpenDebitAccount(Client client, decimal balance, Bank bank)
    {
        var debitAccount = new DebitAccount(client, balance, bank);
        _debitAccounts.Add(debitAccount);
        return debitAccount;
    }

    public CreditAccount OpenCreditAccount(Client client, decimal balance, Bank bank)
    {
        var creditAccount = new CreditAccount(client, balance, bank);
        _creditAccounts.Add(creditAccount);
        return creditAccount;
    }

    public Client AddClient(Client client)
    {
        _clients.Add(client);
        return client;
    }

    public DepositAccount AddDepositAccount(Client client, decimal balance, Bank bank, int time)
    {
        var depositAccount = new DepositAccount(client, balance, bank, time);
        _depositAccounts.Add(depositAccount);
        return depositAccount;
    }
}