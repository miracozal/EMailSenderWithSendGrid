using EMailSenderWithSendGrid.Models;
using FluentValidation;

namespace EMailSenderWithSendGrid.Validators
{
    public class EmailRequestValidator : AbstractValidator<EmailRequest>
    {
        public EmailRequestValidator()
        {
            RuleFor(x => x.Recipient).NotEmpty().EmailAddress();
            RuleFor(x => x.Subject).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Body).NotEmpty();
            RuleFor(x => x.FromMail).NotEmpty().EmailAddress();
            RuleFor(x => x.FromName).NotEmpty();
        }
    }
}
