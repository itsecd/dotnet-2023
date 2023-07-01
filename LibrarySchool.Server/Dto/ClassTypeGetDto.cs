namespace LibrarySchoolServer.Dto;

/// <summary>
/// GetDto type of class ClassTypes
/// </summary>
/// <param name="ClassId">Id group</param>
/// <param name="Number">Number group</param>
/// <param name="Letter">Letter of group</param>
public record ClassTypeGetDto(int ClassId,
                              int Number,
                              string Letter);
