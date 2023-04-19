﻿using AutoMapper;
using LibrarySchool;
using LibrarySchool.Domain;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace LibrarySchoolServer.Controllers;
/// <summary>
/// Controler for class Marks. Defined methods: Post, Put, Get, Delete
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class MarkController : Controller
{
    private readonly ILogger<ClassTypeController> _logger;
    private readonly IDbContextFactory<LibrarySchoolContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for class MakrController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public MarkController(ILogger<ClassTypeController> logger, IDbContextFactory<LibrarySchoolContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _contextFactory = contextFactory;
    }
    /// <summary>
    /// Get list mark
    /// </summary>
    /// <returns>
    /// Return: list mark
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<MarkGetDto>> Get()
    {
        _logger.LogInformation("Get list marks");
        var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<MarkGetDto>>(ctx.Marks);
    }
    /// <summary>
    /// Get mark with certain id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: Ation result Ok if mark exist, NotFound if not exist
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<MarkGetDto>> Get(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundMark = await ctx.Marks.FirstOrDefaultAsync(mark => mark.MarkId == id);
        if (foundMark == null)
        {
            _logger.LogInformation("Not found mark id: {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<MarkGetDto>(foundMark));
    }

    /// <summary>
    /// Add new mark to respository
    /// </summary>
    /// <param name="markToPost"></param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MarkPostDto markToPost)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();  
        var foundStudent = await ctx.Students.FirstOrDefaultAsync(student => student.StudentId == markToPost.StudentId);
        if (foundStudent == null)
            return StatusCode(500, $"Not found student id: {markToPost.StudentId}");
        var foundSubject = await ctx.Subjects.FirstOrDefaultAsync(subject => subject.SubjectId == markToPost.SubjectId);
        if (foundSubject == null)
            return StatusCode(500, $"Not found subject id: {markToPost.SubjectId}");
        await ctx.Marks.AddAsync(_mapper.Map<Mark>(markToPost));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Change information of mark with certain Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fixedMark"></param>
    /// <returns>
    /// Return: IActionResult NotFound if not exist or Ok if exist
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] MarkPostDto fixedMark)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var markToFix = await ctx.Marks.FirstOrDefaultAsync(mark => mark.MarkId == id);
        if (fixedMark == null)
        {
            _logger.LogInformation("Not found mark {id}", id);
            return NotFound();
        }
        _mapper.Map(markToFix, fixedMark);
        ctx.Update(_mapper.Map<Mark>(markToFix));
        await ctx.SaveChangesAsync();   
        return Ok();
    }

    /// <summary>
    /// Delete a mark with certain Id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: IActionResult NotFound if not exist or Ok if student deleted
    /// </returns>

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundMark = await ctx.Marks.FirstOrDefaultAsync(mark => mark.MarkId == id);
        if (foundMark == null)
        {
            _logger.LogInformation("Not found mark id: {id}", id);
            return NotFound();
        }
        ctx.Remove(foundMark);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
