namespace AdmissionCommittee;
/// <summary>
/// Information about the result of the entrant's exam
/// </summary>
public class Result
{
    /// <summary>
    /// IdResult - int value for storing the id result
    /// </summary>
    public int IdResult { get; set; }

    /// <summary>
    /// NameSubject - string value for storing the name of the subject(exam)
    /// </summary>
    public string NameSubject { get; set; }

    /// <summary>
    /// Mark - int value for storing the exam score
    /// </summary>
    public int Mark { get; set; }

    public Result(int idResult, string nameSubject, int mark)
    {
        IdResult = idResult;
        NameSubject = nameSubject;
        Mark = mark;
    }
}