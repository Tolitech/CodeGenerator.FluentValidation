using System;

namespace Tolitech.CodeGenerator.FluentValidation.Validators
{
    public class CpfValidator<T, TProperty> : CpfCnpjBaseValidator<T, TProperty>
    {
        public override string Name => "CpfValidator";

        protected override string GetDefaultMessageTemplate(string errorCode) => Resources.CpfCnpj.CpfCnpjResource.Cpf_Invalid;

        public CpfValidator() : base(isCpf: true, isCnpj: false) { }
    }
}
