using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibrarySchool.Server.Exceptions;

/// <summary>
/// Exception for error not found
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Error code
    /// </summary>
    public int ErrorCode { get; }

    /// <summary>
    /// Constructor for class
    /// </summary>
    /// <param name="message"></param>
    public NotFoundException(string message) : base(message)
    {
        ErrorCode = 404;
    }
}
