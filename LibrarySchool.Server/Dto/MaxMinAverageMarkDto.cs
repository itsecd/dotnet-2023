namespace LibrarySchoolServer.Dto;
/// <summary>
/// Class result querry for Max, Min, Average mark for certain subject
/// </summary>
public class MaxMinAverageMarkDto
{
    /// <summary>
    /// Max of mark value in subject
    /// </summary>
    public double Max { get; set; }

    /// <summary>
    /// Min of mark value in subject
    /// </summary>
    public double Min { get; set; }

    /// <summary>
    /// Average of mark value in subject
    /// </summary>
    public double Average { get; set; }
}
