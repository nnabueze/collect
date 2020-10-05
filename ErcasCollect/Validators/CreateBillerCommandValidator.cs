using System;
using ErcasCollect.Commands.BillerCommand;
using ErcasCollect.Commands.Dto.BillerDto;
using FluentValidation;

namespace ErcasCollect.Validators
{
    public class CreateBillerCommandValidator: BaseDtoValidator<CreateBillerDto>
    {
        public CreateBillerCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
