using Banks.Exception;

namespace Banks.Entities.Clients;

public class Client
{
    private Client(string name, string surname, string passport, string address)
    {
        Name = name;
        Surname = surname;
        Passport = passport;
        Address = address;
    }

    private string Name { get; }
    private string Surname { get; }
    private string Passport { get; }
    private string Address { get; }

    public bool NotDoubtful()
    {
        return !string.IsNullOrEmpty(Passport) && !string.IsNullOrEmpty(Address);
    }

    public void CheckName()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new BanksException("You should fill the gaps");
    }

    public void CheckSurname()
    {
        if (string.IsNullOrWhiteSpace(Surname))
            throw new BanksException("You should fill the gaps");
    }

    public class ClientBuilder
    {
        private string _name = null!;
        private string _surname = null!;
        private string _passport = null!;
        private string _address = null!;
        public ClientBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ClientBuilder SetSurname(string surname)
        {
            _surname = surname;
            return this;
        }

        public ClientBuilder SetPassport(string passport)
        {
            _passport = passport;
            return this;
        }

        public ClientBuilder SetAddress(string address)
        {
            _address = address;
            return this;
        }

        public Client Build()
        {
            return new Client(_name, _surname, _passport, _address);
        }
    }
}