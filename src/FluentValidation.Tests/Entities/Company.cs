using System;

namespace Tolitech.CodeGenerator.FluentValidation.Tests.Entities
{
    public class Company
    {
        public Company(string name, string document)
        {
            Name = name;
            Document = document;
        }

        public string Name { get; private set; }

        public string Document { get; private set; }
    }
}
