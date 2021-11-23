using System;

namespace Tolitech.CodeGenerator.FluentValidation.Validators
{
    public class CpfCnpjValidator<T, TProperty> : CpfCnpjBaseValidator<T, TProperty>
    {
        public override string Name => "CpfCnpjValidator";

        protected override string GetDefaultMessageTemplate(string errorCode) => Resources.CpfCnpj.CpfCnpjResource.CpfCnpj_Invalid;

        public CpfCnpjValidator() : base(isCpf: true, isCnpj: true) { }
    }
}
