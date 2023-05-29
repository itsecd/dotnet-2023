namespace AdmissionCommittee.Server.Dto;
/// <summary>
/// Сlass to output the number of entrants for each specialty according to the first priority
/// </summary>
public class CountEntrantsInEachSpecialtyGetDto
{
    /// <summary>
    /// NameSpecialty - name of specialty
    /// </summary>
    public string NameSpecialty { get; set; }

    /// <summary>
    /// CountEntrants - the number of entrants in each specialty
    /// </summary>
    public int CountEntrants { get; set; }
}