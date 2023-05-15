using System.Transactions;
using Banks.Entities.Banks;
using Banks.Entities.Clients;

namespace Banks.Entities.Accounts;

public abstract class Account
{
    public Account(Client client, decimal balance, Bank bank)
    {
        Balance = balance;
        TransactionHistory = new List<Transaction>();
        BankClient = client;
        Id = Guid.NewGuid();
        CreationTime = DateTime.Now;
        ClientBank = bank;
    }

    public DateTime CreationTime { get; }
    public Bank ClientBank { get; }

    public List<Transaction> TransactionHistory { get; private set; }
    public decimal Balance { get; set; }
    public Client BankClient { get; private set; }
    public Guid Id { get; }

    public void NewTransaction(Transaction transaction)
    {
        TransactionHistory.Add(transaction);
    }

    public abstract void DeductFunds(decimal money);
    public abstract void CreditFunds(decimal money);
    public abstract void BankComission(decimal count);

    public virtual void DayPassed()
    {
    }
}