namespace AdmissionCommittee.Server.Repository;

public interface IAdmissionCommitteeRepository
{
    List<Entrant> GetEntrants { get; }
    List<List<Result>> GetResults { get; }
    List<Specialty> GetSpecialities { get; }
    List<Statement> GetStatements { get; }
}