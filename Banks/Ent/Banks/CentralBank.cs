using Banks.Entities.Accounts;
using Banks.Entities.Clients;
using Banks.Entities.Transactions;

namespace Banks.Entities.Banks;

public class CentralBank
{
    private List<Bank> _banks;
    private List<Transaction> _transactions;
    private List<Client> _clients;

    public CentralBank(string centralBankName)
    {
        _clients = new List<Client>();
        _banks = new List<Bank>();
        _transactions = new List<Transaction>();
        Name = centralBankName;
    }

    public string Name { get; }

    public Bank CreateBank(string name, decimal comissionPercent, decimal creditLimit, decimal payPercent)
    {
        var newBank = new Bank(name, comissionPercent, creditLimit, payPercent);
        _banks.Add(newBank);
        return newBank;
    }

    public void MakeTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public void CancelTransaction(Transaction transaction)
    {
        transaction.Cancel();
        _transactions.Remove(transaction);
    }
}