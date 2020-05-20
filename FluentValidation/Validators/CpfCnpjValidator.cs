using System;

namespace Tolitech.CodeGenerator.FluentValidation.Validators
{
    public class CpfCnpjValidator : CpfCnpjBaseValidator
    {
        internal CpfCnpjValidator(string errorMessage) : base(isCpf: true, isCnpj: true, errorMessage) { }

        public CpfCnpjValidator() : this(Resources.CpfCnpj.CpfCnpjResource.CpfCnpj_Invalid) { }
    }
}
