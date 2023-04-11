﻿namespace AdmissionCommittee.Server.Dto;

public class EntrantResultPostDto
{
    /// <summary>
    /// EntrantId - int value for storing the id entrant
    /// </summary>
    public int EntrantId { get; set; }

    /// <summary>
    /// ResultId - int value for storing the id result
    /// </summary>
    public int ResultId { get; set; }

    /// <summary>
    /// Mark - int value for storing mark for the subject
    /// </summary>
    public int Mark { get; set; }
}