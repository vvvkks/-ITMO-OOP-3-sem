using Banks.Entities.Accounts;

namespace Banks.Entities.Transactions;

public class AddMoney : Transaction
{
    private readonly Account _account;
    private readonly decimal _money;

    public AddMoney(Account account, decimal money)
    {
        _account = account;
        _money = money;
    }

    public override void Cancel()
    {
        IsTransactionExecuted = true;
        _account.DeductFunds(_money);
    }

    public override void Execute()
    {
        IsTransactionExecuted = false;
        _account.CreditFunds(_money);
    }
}