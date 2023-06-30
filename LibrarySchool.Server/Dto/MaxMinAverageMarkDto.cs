namespace LibrarySchoolServer.Dto;

/// <summary>
/// Class result querry for Max, Min, Average mark for certain subject
/// </summary>
/// <param name="Max"></param>
/// <param name="Min"></param>
/// <param name="Average"></param>
public record MaxMinAverageMarkDto(double Max,
                                   double Min,
                                   double Average);
