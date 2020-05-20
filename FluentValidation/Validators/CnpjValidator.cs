using System;

namespace Tolitech.CodeGenerator.FluentValidation.Validators
{
    public class CnpjValidator : CpfCnpjBaseValidator
    {
        internal CnpjValidator(string errorMessage) : base(isCpf: false, isCnpj: true, errorMessage) { }

        public CnpjValidator() : this(Resources.CpfCnpj.CpfCnpjResource.Cnpj_Invalid) { }
    }
}
