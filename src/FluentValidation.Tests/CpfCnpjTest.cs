using System;
using Xunit;
using Tolitech.CodeGenerator.FluentValidation.Tests.Entities;
using Tolitech.CodeGenerator.FluentValidation.Tests.EntityValidators;

namespace Tolitech.CodeGenerator.FluentValidation.Tests
{
    public class CpfCnpjTest
    {
        [Fact(DisplayName = "CpfCnpj - PersonWithCpfValid - Valid")]
        public void CpfCnpj_PersonWithCpfValid_Valid()
        {
            var person = new Person("Name", "999.888.777-14");
            var validator = new PersonCompanyValidator();
            var result = validator.Validate(person);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "CpfCnpj - PersonWithCpfInvalid - Invalid")]
        public void CpfCnpj_PersonWithCpfInvalid_Invalid()
        {
            var person = new Person("Name", "111.111.111-11");
            var validator = new PersonCompanyValidator();
            var result = validator.Validate(person);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "CpfCnpj - PersonWithCnpjValid - Valid")]
        public void CpfCnpj_PersonWithCnpjValid_Valid()
        {
            var person = new Person("Name", "60.316.817/0001-03");
            var validator = new PersonCompanyValidator();
            var result = validator.Validate(person);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "CpfCnpj - PersonWithCnpjInvalid - Invalid")]
        public void CpfCnpj_PersonWithCnpjInvalid_Invalid()
        {
            var person = new Person("Name", "60.316.817/0001-04");
            var validator = new PersonCompanyValidator();
            var result = validator.Validate(person);
            Assert.False(result.IsValid);
        }
    }
}
