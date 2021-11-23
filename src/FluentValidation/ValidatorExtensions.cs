using System;
using FluentValidation;
using Tolitech.CodeGenerator.FluentValidation.Validators;

namespace Tolitech.CodeGenerator.FluentValidation
{
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Defines a 'CNPJ' validator on the current rule builder.
        /// <typeparam name="T">T</typeparam>
        /// <param name="ruleBuilder">rule builder</param>
        /// <returns>a rule builder with cnpj validation included</returns>
        public static IRuleBuilderOptions<T, string> IsValidCNPJ<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CnpjValidator<T, string>());
        }

        /// <summary>
        /// Defines a 'CPF' validator on the current rule builder.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="ruleBuilder">rule builder</param>
        /// <returns>a rule builder with cpf validation included</returns>
        public static IRuleBuilderOptions<T, string> IsValidCPF<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfValidator<T, string>());
        }

        /// <summary>
        /// Defines a 'CPF' or ''CNPJ validator on the current rule builder.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="ruleBuilder">rule builder</param>
        /// <returns>a rule builder with cnpj or cpf validation included</returns>
        public static IRuleBuilderOptions<T, string> IsValidCPFOrCNPJ<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfCnpjValidator<T, string>());
        }
    }
}
