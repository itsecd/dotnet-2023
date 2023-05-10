namespace SchoolServer.Dto
{
    public class SubjectPostDto
    {
        /// <summary>
        /// Наименование предмета
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Год обучения
        /// </summary>
        public int Year { get; set; }
    }
}
