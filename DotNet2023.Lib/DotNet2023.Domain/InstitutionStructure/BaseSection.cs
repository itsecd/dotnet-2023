﻿using System.ComponentModel.DataAnnotations;

namespace DotNet2023.Domain.InstitutionStructure;

/// <summary>
/// The class contains a basic description of the institute's department
/// <param name="Id">Autogenerated primary key in string format. Represents Guid</param>
/// <param name="Name">Name of study department</param>
/// <param name="Email">Email. Format lalala@lala.la</param>
/// <param name="Phone">Phone. Format @[0-9]{11}</param>
/// </summary>
public class BaseSection
{
    [Required]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    // TODO rename Name to Title
    public string? Name { get; set; }

    [RegularExpression(@"\\S+@\\S+\\.\\S+$")]
    public string? Email { get; set; }
    [RegularExpression(@"[0-9]{10}")]
    public string? Phone { get; set; }
}
