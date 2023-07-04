namespace LibrarySchool.Server.Exceptions;

/// <summary>
/// Exception of bad request
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// Error code
    /// </summary>
    public int ErrorCode { get; }

    /// <summary>
    /// Constructor for class
    /// </summary>
    /// <param name="message"></param>
    public BadRequestException(string message) : base(message)
    {
        ErrorCode = 400;
    }
}