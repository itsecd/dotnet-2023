namespace LibrarySchoolServer.Dto;

/// <summary>
/// GetDto type of class ClassTypes
/// </summary>
/// <param name="ClassId"></param>
/// <param name="Number"></param>
/// <param name="Letter"></param>
public record ClassTypeGetDto(int ClassId,
                              int Number,
                              string Letter);
