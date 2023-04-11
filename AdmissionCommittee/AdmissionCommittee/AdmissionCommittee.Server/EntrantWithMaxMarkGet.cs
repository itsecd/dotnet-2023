namespace AdmissionCommittee.Server;
/// <summary>
/// Class to output entrants with maximum mark in each subject
/// </summary>
public class EntrantWithMaxMarkGet
{
    /// <summary>
    /// NameEntrant - name entrant
    /// </summary>
    public string NameEntrant { get; set; }

    /// <summary>
    /// NameSpecialty - name speciality entrant's
    /// </summary>
    public string NameSpecialty { get; set; }

    /// <summary>
    /// MaxMark - max mark in the subject
    /// </summary>
    public int MaxMark { get; set; }
}