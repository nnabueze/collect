using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers.EnumClasses;
using ErcasCollect.Validators;

namespace ErcasCollect.Commands.Dto.BillerDto
{
    public class CreateBillerDto: BaseDto, IValidatableObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int StateId { get; set; }
        public int BillerTypeId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Abbreviation { get; set; }
        public bool IsGatewayOnbaord { get; set; }
        public int Commission { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var validator = new CreateBillerCommandValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(Items => new ValidationResult(Items.ErrorMessage, new[] { Items.PropertyName }));
        }

    }
}
