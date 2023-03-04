namespace Polyclinic.Domain;
public class Registration
{
    public int IdPatient { get; set; } = 0;
    public int IdDoctor { get; set; } = 0;
    public DateTime TimeAdmission { get; set; } = new DateTime();

    public Registration(int idPatient, int idDoctor, DateTime timeAdmission)
    {
        IdPatient = idPatient;
        IdDoctor = idDoctor;
        TimeAdmission = timeAdmission;
    }
}
