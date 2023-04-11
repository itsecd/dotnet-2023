﻿using AutoMapper;
using SchoolServer.Dto;
using SchoolServer.Repository;
using Microsoft.AspNetCore.Mvc;
using School.Classes;

namespace SchoolServer.Controllers;

/// <summary>
/// Контроллер класса
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    private readonly ILogger<ClassController> _logger;

    private readonly ISchoolRepository _diaryRepository;

    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера 
    /// </summary>
    public ClassController(ILogger<ClassController> logger, ISchoolRepository diaryRepository, IMapper mapper)
    {
        _logger = logger;
        _diaryRepository = diaryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Метод получения данных всей коллекции для классов
    /// </summary>
    /// <returns>Коллекция классов</returns>
    [HttpGet]
    public IEnumerable<ClassGetDto> Get()
    { 
        return _diaryRepository.Classes.Select(obj => _mapper.Map<ClassGetDto>(obj));
    }

    /// <summary>
    /// Метод получения класса по id 
    /// </summary>
    /// <param name="id">id класса</param>
    /// <returns>Найденный класс по id</returns>
    [HttpGet("{id}")]
    public ActionResult<Class> Get(int id)
    {
        var diaryClass = _diaryRepository.Classes.FirstOrDefault(obj => obj.Id == id);
        if (diaryClass == null) 
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(diaryClass);
        }
    }

    /// <summary>
    /// Метод добавления элементов в коллекцию с помощью json
    /// </summary>
    /// <param name="class">объект класса ClassGetDto</param>
    [HttpPost]
    public void Post([FromBody] ClassGetDto @class)
    {
        _diaryRepository.Classes.Add(_mapper.Map<Class>(@class));
    }
    
    /// <summary>
    /// Метод обновления данных по id
    /// </summary>
    /// <param name="id">id объекта</param>
    /// <param name="class">Объект, данные которого будут изменены</param>
    /// <returns>Обновленный по id элемент</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClassPostDto @class)
    {
        var diaryClass = _diaryRepository.Classes.FirstOrDefault(obj => obj.Id == id);
        if (diaryClass == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(@class, diaryClass);
            return Ok();
        }
    }
    
    /// <summary>
    /// Метод удаления элемента по id
    /// </summary>
    /// <param name="id">id объекта</param>
    /// <returns>Успех или ошибка удаления</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var diaryClass = _diaryRepository.Classes.FirstOrDefault(obj => obj.Id == id);
        if (diaryClass == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _diaryRepository.Classes.Remove(diaryClass);
            return Ok();
        }
    }
    
}
