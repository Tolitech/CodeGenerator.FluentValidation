using System;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace Tolitech.CodeGenerator.FluentValidation.Validators
{
    public abstract class CpfCnpjBaseValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        private const int cpfLength = 11;
        private const int cnpjLength = 14;

        private readonly bool isCpf;
        private readonly bool isCnpj;

        protected int[] CpfFirstMultiplierCollection => new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        protected int[] CpfSecondMultiplierCollection => new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        protected int[] CnpjFirstMultiplierCollection => new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        protected int[] CnpjSecondMultiplierCollection => new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        protected CpfCnpjBaseValidator(bool isCpf, bool isCnpj) : base()
        {
            this.isCpf = isCpf;
            this.isCnpj = isCnpj;
        }

        public override bool IsValid(ValidationContext<T> context, TProperty property)
        {
            var value = property as string ?? string.Empty;
            value = Regex.Replace(value, "[^0-9]", "");

            if (string.IsNullOrEmpty(value))
                return true;

            if (IsInvalidLength(value) || AllDigitsAreEqual(value))
                return false;

            var document = value.Select(x => (int)Char.GetNumericValue(x)).ToArray();
            var digits = GetDigits(document);

            return value.EndsWith(digits);
        }

        private static bool AllDigitsAreEqual(string value) => value.All(x => x == value.FirstOrDefault());

        private bool IsInvalidLength(string value)
        {
            bool invalid = false;

            if (!string.IsNullOrWhiteSpace(value))
            {
                if (isCpf == true && isCnpj == true)
                {
                    if (value.Length != cpfLength && value.Length != cnpjLength)
                        invalid = true;
                }
                else if (isCpf == true)
                {
                    if (value.Length != cpfLength)
                        invalid = true;
                }
                else if (isCnpj == true)
                {
                    if (value.Length != cnpjLength)
                        invalid = true;
                }
                else
                    invalid = true;
            }

            return invalid;
        }

        private string GetDigits(int[] document)
        {
            int first = 0;
            int second = 0;

            if (document.Length == cpfLength)
            {
                first = CalculateValue(CpfFirstMultiplierCollection, document);
                second = CalculateValue(CpfSecondMultiplierCollection, document);
            }
            else if (document.Length == cnpjLength)
            {
                first = CalculateValue(CnpjFirstMultiplierCollection, document);
                second = CalculateValue(CnpjSecondMultiplierCollection, document);
            }

            return $"{CalculateDigit(first)}{CalculateDigit(second)}";
        }

        private static int CalculateValue(int[] weight, int[] numbers)
        {
            var sum = 0;
            for (int i = 0; i < weight.Length; i++) sum += weight[i] * numbers[i];
            return sum;
        }

        private static int CalculateDigit(int sum)
        {
            int modResult = (sum % 11);
            return modResult < 2 ? 0 : 11 - modResult;
        }
    }
}