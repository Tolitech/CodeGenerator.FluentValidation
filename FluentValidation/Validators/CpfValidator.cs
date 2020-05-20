using System;

namespace Tolitech.CodeGenerator.FluentValidation.Validators
{
    public class CpfValidator : CpfCnpjBaseValidator
    {
        internal CpfValidator(string errorMessage) : base(isCpf: true, isCnpj: false, errorMessage) { }

        public CpfValidator() : this(Resources.CpfCnpj.CpfCnpjResource.Cpf_Invalid) { }
    }
}
