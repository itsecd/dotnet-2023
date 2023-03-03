namespace Polyclinic.Domain;
public class Completion
{   
    public string Conclusion { get; set; } = string.Empty;
    public int IdDoctor { get; set; } = 0;
    public int IdPatient { get; set; } = 0;
    public int Status { get; set; } = 0; // 0 - on treatment // 1 - healthy

}
