using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace School.Classes;

public class Grade
{
    /// <summary>
    /// Предмет
    /// </summary>
    public Subject? Subject { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public Students Student { get; set; }
    public Grade() { }

    public Grade(Subject subject, Students student)
    {
        Subject = subject;
        Student = student;
    }
}