using System;

namespace Tolitech.CodeGenerator.FluentValidation.Validators
{
    public class CnpjValidator<T, TProperty> : CpfCnpjBaseValidator<T, TProperty>
    {
        public override string Name => "CnpjValidator";

        protected override string GetDefaultMessageTemplate(string errorCode) => Resources.CpfCnpj.CpfCnpjResource.Cnpj_Invalid;

        public CnpjValidator() : base(isCpf: false, isCnpj: true) { }
    }
}
