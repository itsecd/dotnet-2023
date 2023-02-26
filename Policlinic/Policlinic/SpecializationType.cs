using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policlinic;
public class SpecializationType
{
    public string Specialization { get; set; } = string.Empty;

    public SpecializationType() { }

    public SpecializationType(string specialization)
    {
        Specialization = specialization;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not SpecializationType param)
            return false;
        return Specialization == param.Specialization;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Specialization);
    }
}
