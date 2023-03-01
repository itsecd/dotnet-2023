using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain;

/// <summary>	
/// Группа.	
/// </summary>	
public class Group
{
    #region Свойства.	
    /// <summary>	
    /// Идентификатор.	
    /// </summary>	
    public int GroupId { get; private set; }

    /// <summary>	
    /// Название.	
    /// </summary>	
    public string Name { get; private set; }

    /// <summary>	
    /// Описание.	
    /// </summary>	
    public string Description { get; private set; }

    /// <summary>	
    /// Дата создания.	
    /// </summary>	
    public DateTime CreationDate { get; private set; }

    /// <summary>
    /// Идентификатор создателя.
    /// </summary>
    public int UserId { get; private set; }

    /// <summary>
    /// Создатель.
    /// </summary>
    public User User { get; private set; }

    /// <summary>
    /// Записи группы.
    /// </summary>
    public List<Note> Notes { get; private set; }
    #endregion

    #region Конструкторы.
    /// <summary>
    /// Создает группу с помощью указанных данных.
    /// </summary>
    /// <param name="groupId">Идентификатор группы.</param>
    /// <param name="name">Название.</param>
    /// <param name="description">Описание.</param>
    /// <param name="creationDate">Дата создания.</param>
    /// <param name="userId">Идентификатор создателя группы.</param>
    /// <param name="user">Создатель группы.</param>
    /// <param name="notes">Список записей группы.</param>
    /// <exception cref="ArgumentNullException">Объект равен null!</exception>
    /// <exception cref="ArgumentOutOfRangeException">Числовое значение вышло за границы!</exception>
    public Group(int groupId, string name, string description, DateTime creationDate, int userId,
        User user, List<Note> notes)
    {
        #region Валидация входных параметров.
        Validator.RangeNumberValidate(0, int.MaxValue, groupId);
        Validator.StringTextValidate(name);
        Validator.StringTextValidate(description);
        Validator.DateTimeValidate(creationDate);
        Validator.RangeNumberValidate(0, int.MaxValue, userId);
        Validator.UserValidate(user);
        Validator.ListValidate(notes);
        #endregion

        GroupId = groupId;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        UserId = userId;
        User = user;
        Notes = notes;
    }

    /// <summary>
    /// Создает группу с помощью параметров по умолчанию.
    /// </summary>
    public Group() 
        : this(1, "Название группы", "Описание группы", DateTime.Now, 1, new User(), new List<Note>())
    {
    }
    #endregion

}