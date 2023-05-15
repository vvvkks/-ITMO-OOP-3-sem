using Banks.Entities.Banks;
using Banks.Entities.Clients;
using Banks.Exception;

namespace Banks.Entities.Accounts;

public class DebitAccount : Account
{
    public DebitAccount(Client client, decimal balance, Bank bank)
        : base(client, balance, bank)
    {
    }

    public override void CreditFunds(decimal money)
    {
         Balance += money;
    }

    public override void DeductFunds(decimal money)
    {
        if (Balance < 0 || Balance - money < 0)
            throw new BanksException("Not enough money");
        Balance -= money;
    }

    public override void BankComission(decimal count)
    {
        return;
    }

    public override void DayPassed()
    {
        Balance += (Balance * ClientBank.PayPercent) / (365 * 100);
    }

    public decimal GetBalance()
    {
        return Balance;
    }
}