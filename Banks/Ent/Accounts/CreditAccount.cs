using Banks.Entities.Banks;
using Banks.Entities.Clients;
using Banks.Entities.Transactions;
using Banks.Exception;

namespace Banks.Entities.Accounts;

public class CreditAccount : Account
{
    public CreditAccount(Client client, decimal balance, Bank bank)
        : base(client, balance, bank)
    {
    }

    public override void DayPassed()
    {
        if (Balance < 0 && Balance > -ClientBank.CreditLimit)
        {
            Balance -= ClientBank.ComissionPercent;
        }
    }

    public override void DeductFunds(decimal money)
    {
        if (Balance - money < -ClientBank.CreditLimit)
            throw new BanksException("More than limit");
        Balance -= money;
    }

    public override void CreditFunds(decimal money)
    {
         Balance += money;
    }

    public override void BankComission(decimal count)
    {
        decimal newBalance = Balance - ClientBank.ComissionPercent;
        if (newBalance >= -ClientBank.ComissionPercent)
        {
            Balance = newBalance;
        }
    }
}