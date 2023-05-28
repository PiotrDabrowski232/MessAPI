using FluentValidation;
using MessAPI.Models;

namespace MessAPI.Validators
{
    public class MessageValidator : AbstractValidator<Message>
    {

        public MessageValidator()
        {
            RuleFor(m => m.Title)
                .MaximumLength(20)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title of message is empty");


            RuleFor(m => m.Body)
                .MaximumLength(150)
                .NotEmpty()
                .NotNull()
                .WithMessage("Body of message is empty");


            RuleFor(m => m.Type)
                .Must(m => m.ToUpper()=="POSITIVE"|| m.ToUpper() == "NEGATIVE"|| m.ToUpper() == "NEUTRAL")
                .WithMessage("Type of message is empty or is incorrect");

        }



    }
}
