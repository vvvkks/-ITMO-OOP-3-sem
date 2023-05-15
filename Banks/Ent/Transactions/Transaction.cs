using Banks.Entities.Accounts;
using Banks.Entities.Clients;

namespace Banks.Entities.Transactions;

public abstract class Transaction
{
    public bool IsTransactionExecuted { get; set; }
    public abstract void Cancel();
    public abstract void Execute();
}