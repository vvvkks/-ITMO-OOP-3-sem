using Banks.Entities.Banks;
using Banks.Entities.Clients;
using Banks.Entities.Transactions;
using Banks.Exception;

namespace Banks.Entities.Accounts;

public class DepositAccount : Account
{
    private int _time;
    private int _timeLimit;
    private decimal _moneyBuffer;
    public DepositAccount(Client client, decimal balance, Bank bank, int time)
        : base(client, balance, bank)
    {
        _time = time;
        _timeLimit = 0;
        _moneyBuffer = 0;
    }

    public override void DeductFunds(decimal money)
    {
        if (_time < 0)
            throw new BanksException("Can't send money before the release date");
        Balance -= money;
    }

    public override void CreditFunds(decimal money)
    {
        Balance += money;
    }

    public override void BankComission(decimal count)
    {
        return;
    }

    public override void DayPassed()
    {
        _timeLimit++;
        if (_timeLimit <= _time)
        {
            _moneyBuffer += (Balance * ClientBank.PayPercent) / (365 * 100);
        }

        if (_timeLimit == _time)
        {
            Balance += _moneyBuffer;
            _moneyBuffer = 0;
        }
    }

    public decimal GetBalance()
    {
        return Balance;
    }
}