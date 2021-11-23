using System;
using FluentValidation;
using Tolitech.CodeGenerator.FluentValidation.Tests.Entities;

namespace Tolitech.CodeGenerator.FluentValidation.Tests.EntityValidators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Document)
                .IsValidCPF();
        }
    }
}
