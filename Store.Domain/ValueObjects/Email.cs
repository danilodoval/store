using FluentValidator;

namespace Store.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            new ValidationContract<Email>(this)
                .IsEmail(X => X.Address);
        }

        public string Address { get; private set; }
    }
}
