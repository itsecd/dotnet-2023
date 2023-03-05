namespace School.Classes;
{
    public class Class
    {
        /// <summary>
        /// Список студентов
        /// </summary>
        public List<Students>? Students { get; set; }

        /// <summary>
        /// Номер класса
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Литера класса
        /// </summary>
        public char Letter { get; set; }

        public Class() { }

        public Class(List<Students> students, int number, char letter)
        {
            Students = students;
            Number = number;
            Letter = letter;
        }
    }
}