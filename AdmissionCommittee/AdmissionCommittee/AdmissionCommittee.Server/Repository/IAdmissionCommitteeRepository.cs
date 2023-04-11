using AdmissionCommittee.Model;

namespace AdmissionCommittee.Server.Repository;
public interface IAdmissionCommitteeRepository
{
    List<EntrantResult> EntrantResultsWithResult { get; }
    List<Entrant> EntrantsWithEntrantResult { get; }
    List<Entrant> EntrantsWithStatement { get; }
    List<Result> Results { get; }
    List<Specialty> Specialties { get; }
    List<Statement> Statements { get; }
    List<StatementSpecialty> StatementSpecialtiesWithSpecialty { get; }
}