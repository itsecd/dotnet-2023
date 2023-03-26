namespace LibrarySchoolServer.Dto;

/// <summary>
/// GetDto type of class ClassType
/// </summary>
public class ClassTypeGetDto
{
    ///<summary>
    /// ClassId - Id class 
    ///</summary>
    public int ClassId { get; set; }

    ///<summary>
    /// Number - number of class, example: 6312,...
    ///</summary>
    public int Number { get; set; }

    ///<summary>
    /// Letter - letter of speciality, example: 10-05-03D,...
    ///</summary>
    public string Letter { get; set; } = "";
}
