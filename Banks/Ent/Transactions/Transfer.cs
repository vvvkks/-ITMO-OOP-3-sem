using System.Runtime.Serialization;
using Banks.Entities.Accounts;
using Banks.Exception;

namespace Banks.Entities.Transactions;

public class Transfer : Transaction
{
    private const int MinimalMoney = 0;
    private readonly Account _sender;
    private readonly Account _recipient;
    private readonly decimal _money;
    public Transfer(Account from, Account to, decimal money)
    {
        if (money <= MinimalMoney)
        {
            throw new BanksException("Not enough money");
        }

        _sender = from;
        _recipient = to;
        _money = money;
    }

    public override void Cancel()
    {
        IsTransactionExecuted = true;
        _sender.CreditFunds(_money);
        _recipient.DeductFunds(_money);
    }

    public override void Execute()
    {
        IsTransactionExecuted = false;
        _sender.DeductFunds(_money);
        _recipient.CreditFunds(_money);
    }
}