namespace AdmissionCommittee.Server.Repository;

public interface IAdmissionCommitteeRepository
{
    List<Entrant> Entrants { get; }
    List<List<Result>> Results { get; }
    List<Speciality> Specialities { get; }
    List<Statement> Statements { get; }
}