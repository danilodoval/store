using FluentValidator;
using Store.Domain.Commands.Inputs;
using Store.Domain.Commands.Results;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.Resources;
using Store.Domain.Services;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.CommandHandlers.Handlers
{
    public class CustomerCommandHandler : Notifiable, ICommandHandler<PlaceCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(PlaceCustomerCommand command)
        {
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Document already exist");
                return null;
            }

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);

            var customer = new Customer(name, email, document, user);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);

            if (IsValid())
                _customerRepository.Save(customer);

            _emailService.Send(
                customer.Name.ToString(),
                customer.Email.Address,
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name));

            return new PlaceCustomerCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}
