namespace LibrarySchoolServer.Dto;

/// <summary>
/// Class result querry for Max, Min, Average mark for certain subject
/// </summary>
/// <param name="Max">Max value mark of subject</param>
/// <param name="Min">Min value mark of subject</param>
/// <param name="Average">Average value mark of subject</param>
public record MaxMinAverageMarkDto(double Max,
                                   double Min,
                                   double Average);
