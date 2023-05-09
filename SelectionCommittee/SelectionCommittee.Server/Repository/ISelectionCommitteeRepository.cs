using SelectionCommittee.Domain;

namespace SelectionCommittee.Server.Repository;

/// <summary>
/// Содержит методы для репозитория приемной комиссии.
/// </summary>
public interface ISelectionCommitteeRepository
{
    /// <summary>
    /// Получение всех абитуриентов.
    /// </summary>
    /// <returns>Последовательность абитуриентов.</returns>
    Task<IEnumerable<Enrollee>> GetEnrollees();

    /// <summary>
    /// Получение абитуриента по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор абитуриента, которого необходимо получить.</param>
    /// <returns>Абитуриента.</returns>
    Task<Enrollee?> GetEnrollee(int id);

    /// <summary>
    /// Создание абитуриента.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания абитуриента.</param>
    Task<int> AddEnrollee(Enrollee model);

    /// <summary>
    /// Изменение данных абитуриента.
    /// </summary>
    /// <param name="id">Идентификатор абитуриента, данные которого необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимому абитуриенту.</param>
    Task UpdateEnrollee(int id, Enrollee model);

    /// <summary>
    /// Удаление абитуриента по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор абитуриента, которого необходимо удалить.</param>
    Task DeleteEnrollee(int id);

    /// <summary>
    /// Получение всех результатов экзаменов.
    /// </summary>
    /// <returns>Последовательность результатов экзаменов.</returns>
    Task<IEnumerable<ExamResult>> GetExamResults();

    /// <summary>
    /// Получение результата экзамена по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор результата экзамена, который необходимо получить.</param>
    /// <returns>Запись.</returns>
    Task<ExamResult?> GetExamResult(int id);

    /// <summary>
    /// Создание результата экзамена.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания результата экзамена.</param>
    Task<int> AddExamResult(ExamResult model);

    /// <summary>
    /// Изменение данных результата экзамена.
    /// </summary>
    /// <param name="id">Идентификатор результата экзамена, данные которого необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимому результату экзамена.</param>
    Task UpdateExamResult(int id, ExamResult model);

    /// <summary>
    /// Удаление результата экзамена по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор результата экзамена, которого необходимо удалить.</param>
    Task DeleteExamResult(int id);

    /// <summary>
    /// Получение всех факультетов.
    /// </summary>
    /// <returns>Последовательность факультетов.</returns>
    Task<IEnumerable<Faculty>> GetFaculties();

    /// <summary>
    /// Получение факультета по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета, которого необходимо получить.</param>
    /// <returns>Факутет.</returns>
    Task<Faculty?> GetFaculty(int id);

    /// <summary>
    /// Создание факультета.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания факультета.</param>
    Task<int> AddFaculty(Faculty model);

    /// <summary>
    /// Изменение данных факультета.
    /// </summary>
    /// <param name="id">Идентификатор факультета, данные которого необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимому факультету.</param>
    Task UpdateFaculty(int id, Faculty model);

    /// <summary>
    /// Удаление факультета по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета, которого необходимо удалить.</param>
    Task DeleteFaculty(int id);

    /// <summary>
    /// Получение всех специальностей.
    /// </summary>
    /// <returns>Последовательность специальностей.</returns>
    Task<IEnumerable<Specialization>> GetSpecializations();

    /// <summary>
    /// Получение специальности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности, которую необходимо получить.</param>
    /// <returns>Специальность.</returns>
    Task<Specialization?> GetSpecialization(int id);

    /// <summary>
    /// Создание специальности.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания специальности.</param>
    Task<int> AddSpecialization(Specialization model);

    /// <summary>
    /// Изменение данных специальности.
    /// </summary>
    /// <param name="id">Идентификатор специальности, данные которой необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимой специальности.</param>
    Task UpdateSpecialization(int id, Specialization model);

    /// <summary>
    /// Удаление специальности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности, которую необходимо удалить.</param>
    Task DeleteSpecialization(int id);
}
