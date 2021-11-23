using System;
using FluentValidation;
using Tolitech.CodeGenerator.FluentValidation.Tests.Entities;

namespace Tolitech.CodeGenerator.FluentValidation.Tests.EntityValidators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Document)
                .IsValidCNPJ();
        }
    }
}
