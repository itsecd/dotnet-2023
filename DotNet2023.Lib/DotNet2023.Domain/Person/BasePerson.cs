﻿using System.ComponentModel.DataAnnotations;

namespace DotNet2023.Domain.Person;

/// <summary>
/// The class is a basic description of a person.
/// <param name="Id">Autogenerated primary key in string format. Represents Guid</param>
/// <param name="Name">Name of the person</param>
/// <param name="Surname">Surname of the person</param>
/// <param name="Patronymic">Patronymic of the person</param>
/// <param name="BirthDay">Birthday. Format DD.MM.YYYY</param>
/// <param name="Email">Email. Format lalala@lala.la</param>
/// <param name="Phone">Phone. Format @[0-9]{11}</param>
/// </summary>
public class BasePerson
{

    [Required]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }

    public DateTime? BirthDay { get; set; }

    [RegularExpression(@"\\S+@\\S+\\.\\S+$")]
    public string? Email { get; set; }

    [RegularExpression(@"[0-9]{10}")]
    public string? Phone { get; set; }
}
