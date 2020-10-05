using System;
using ErcasCollect.Commands.Dto;
using ErcasCollect.Commands.Dto.BillerDto;
using FluentValidation;

namespace ErcasCollect.Validators
{
    public class BaseDtoValidator<T> : AbstractValidator<T> where T : BaseDto
    {
        public BaseDtoValidator()
        {
                       
        }





    }
}
