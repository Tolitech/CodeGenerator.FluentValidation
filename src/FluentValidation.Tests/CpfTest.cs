using System;
using Xunit;
using Tolitech.CodeGenerator.FluentValidation.Tests.Entities;
using Tolitech.CodeGenerator.FluentValidation.Tests.EntityValidators;

namespace Tolitech.CodeGenerator.FluentValidation.Tests
{
    public class CpfTest
    {
        [Fact(DisplayName = "Cpf - PersonOneWithCpfValid - Valid")]
        public void Cpf_PersonOneWithCpfValid_Valid()
        {
            var person = new Person("Name", "999.888.777-14");
            var validator = new PersonValidator();
            var result = validator.Validate(person);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Cpf - PersonTwoWithCpfValid - Valid")]
        public void Cpf_PersonTwoWithCpfValid_Valid()
        {
            var person = new Person("Name", "99988877714");
            var validator = new PersonValidator();
            var result = validator.Validate(person);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Cpf - PersonOneWithCpfInvalid - Invalid")]
        public void Cpf_PersonOneWithCpfInvalid_Invalid()
        {
            var person = new Person("Name", "111.111.111-11");
            var validator = new PersonValidator();
            var result = validator.Validate(person);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Cpf - PersonTwoWithCpfInvalid - Invalid")]
        public void Cpf_PersonTwoWithCpfInvalid_Invalid()
        {
            var person = new Person("Name", "11111111111");
            var validator = new PersonValidator();
            var result = validator.Validate(person);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Cpf - PersonThreeWithCpfInvalid - Invalid")]
        public void Cpf_PersonThreeWithCpfInvalid_Invalid()
        {
            var person = new Person("Name", "111");
            var validator = new PersonValidator();
            var result = validator.Validate(person);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Cpf - PersonWithEmptyCpf - Valid")]
        public void Cpf_PersonWithEmptyCpf_Valid()
        {
            var person = new Person("Name", "");
            var validator = new PersonValidator();
            var result = validator.Validate(person);
            Assert.True(result.IsValid);
        }
    }
}
