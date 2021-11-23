# Tolitech.CodeGenerator.FluentValidation
FluentValidation library used in projects created by the Code Generator tool.

This project contains basic validations used frequently, such as CPF and CNPJ validation through the FluentValidation library. 

Tolitech Code Generator Tool: [http://www.tolitech.com.br](https://www.tolitech.com.br/)

Examples:

```
public class Person
{
    public Person(string name, string document)
    {
        Name = name;
        Document = document;
    }

    public string Name { get; private set; }

    public string Document { get; private set; }
}
```

```
public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Document)
            .IsValidCPF();
    }
}
```

```
var person = new Person("Name", "999.888.777-14");
var validator = new PersonValidator();
var result = validator.Validate(person); // result.IsValid == true
```

```
var person = new Person("Name", "99988877714");
var validator = new PersonValidator();
var result = validator.Validate(person); // result.IsValid == true
```

```
RuleFor(x => x.Document)
    .IsValidCPF();
```

```
RuleFor(x => x.Document)
    .IsValidCNPJ();
```

```
RuleFor(x => x.Document)
    .IsValidCPFOrCNPJ();
```