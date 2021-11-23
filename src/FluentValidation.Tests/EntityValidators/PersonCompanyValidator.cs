using System;
using FluentValidation;
using Tolitech.CodeGenerator.FluentValidation.Tests.Entities;

namespace Tolitech.CodeGenerator.FluentValidation.Tests.EntityValidators
{
    public class PersonCompanyValidator : AbstractValidator<Person>
    {
        public PersonCompanyValidator()
        {
            RuleFor(x => x.Document)
                .IsValidCPFOrCNPJ();
        }
    }
}
