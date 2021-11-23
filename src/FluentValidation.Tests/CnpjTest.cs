using System;
using Xunit;
using Tolitech.CodeGenerator.FluentValidation.Tests.Entities;
using Tolitech.CodeGenerator.FluentValidation.Tests.EntityValidators;

namespace Tolitech.CodeGenerator.FluentValidation.Tests
{
    public class CnpjTest
    {
        [Fact(DisplayName = "Cnpj - CompanyOneWithCnpjValid - Valid")]
        public void Cnpj_CompanyOneWithCnpjValid_Valid()
        {
            var company = new Company("Name", "60.316.817/0001-03");
            var validator = new CompanyValidator();
            var result = validator.Validate(company);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Cnpj - CompanyTwoWithCnpjValid - Valid")]
        public void Cnpj_CompanyTwoWithCnpjValid_Valid()
        {
            var company = new Company("Name", "60316817000103");
            var validator = new CompanyValidator();
            var result = validator.Validate(company);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Cnpj - CompanyOneWithCnpjInvalid - Invalid")]
        public void Cnpj_CompanyOneWithCnpjInvalid_Invalid()
        {
            var company = new Company("Name", "60.316.817/0001-04");
            var validator = new CompanyValidator();
            var result = validator.Validate(company);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Cnpj - CompanyTwoWithCnpjInvalid - Invalid")]
        public void Cnpj_CompanyTwoWithCnpjInvalid_Invalid()
        {
            var company = new Company("Name", "60316817000104");
            var validator = new CompanyValidator();
            var result = validator.Validate(company);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Cnpj - CompanyThreeWithCnpjInvalid - Invalid")]
        public void Cnpj_CompanyThreeWithCnpjInvalid_Invalid()
        {
            var company = new Company("Name", "111");
            var validator = new CompanyValidator();
            var result = validator.Validate(company);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Cnpj - CompanyWithEmptyCnpj - Valid")]
        public void Cnpj_CompanyWithEmptyCnpj_Valid()
        {
            var company = new Company("Name", "");
            var validator = new CompanyValidator();
            var result = validator.Validate(company);
            Assert.True(result.IsValid);
        }
    }
}
