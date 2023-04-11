namespace PoliclinicTests;

public class PoliclinicTest : IClassFixture<PoliclinicTestFixture>
{
    private readonly PoliclinicTestFixture _fixture;

    public PoliclinicTest(PoliclinicTestFixture fixture)
    {
        _fixture = fixture;
    }
    /// <summary>
    /// Display information about all doctors whose work experience is at least 10 years
    /// </summary>
    [Fact]
    public void FirstRequest()
    {
        var doctorList = _fixture.CreateDefaultDoctors;
        var requestDoctorList = (from doctor in doctorList
                                 where doctor.WorkExperience >= 10
                                 select doctor).ToList();
        Assert.Equal(doctorList[1], requestDoctorList[0]);
    }
    /// <summary>
    /// Display information about all patients who have made an appointment with the specified doctor, arrange by name
    /// </summary>
    [Fact]
    public void SecondRequest()
    {
        var patientList = _fixture.CreateDefaultPatients;
        var doctorList = _fixture.CreateDefaultDoctors;
        var receptionList = _fixture.CreateDefaultReceptions;
        var requestPatientList = (from patient in patientList
                                  join reception in receptionList on patient.Id equals reception.PatientId
                                  join doctor in doctorList on reception.DoctorId equals doctor.Id
                                  where reception.DoctorId == 10
                                  orderby patient.Fio
                                  select patient).ToList();
        Assert.Equal(patientList[1], requestPatientList[0]);
    }
    /// <summary>
    /// Display information about currently healthy patients
    /// </summary>
    [Fact]
    public void ThirdRequest()
    {
        var receptionList = _fixture.CreateDefaultReceptions;
        var patientList = _fixture.CreateDefaultPatients;
        var requestHealthyPatientList = (from patient in patientList
                                         join reception in receptionList on patient.Id equals reception.PatientId
                                         where reception.Status == "Healthy"
                                         select patient).Distinct().ToList();
        Assert.Equal(patientList[1], requestHealthyPatientList[0]);
        Assert.Equal(patientList[2], requestHealthyPatientList[1]);
    }
    /// <summary>
    /// Display information about the number of patient appointments by doctors for the last month
    /// </summary>
    [Fact]
    public void FourthRequest()
    {
        var receptionList = _fixture.CreateDefaultReceptions;
        var doctorList = _fixture.CreateDefaultDoctors;
        var requestCountReceptionsInOneMonth = (from doctor in doctorList
                                                join reception in receptionList on doctor.Id equals reception.DoctorId
                                                where reception.DateAndTime > new DateTime(2023, 1, 31) && reception.DateAndTime < new DateTime(2023, 3, 1)
                                                orderby doctor.Receptions.Count descending
                                                select new
                                                {
                                                    count = doctor.Receptions.Count,
                                                    key = doctor.Fio
                                                }).Distinct().ToList();
        Assert.Equal(2, requestCountReceptionsInOneMonth[0].count);
    }
    /// <summary>
    /// Display information about the top 5 most common diseases among patients
    /// </summary>
    [Fact]
    public void FifthRequest()
    {
        var receptionList = _fixture.CreateDefaultReceptions;
        var requestTopDiseases = (from reception in receptionList
                                  where reception.Conclusion != ""
                                  orderby reception.Conclusion
                                  select reception.Conclusion).Take(5).ToList();
        Assert.Equal("Nervousness", requestTopDiseases[0]);
        Assert.Equal("Psoriasis", requestTopDiseases[1]);
    }
    /// <summary>
    /// Display information about patients over the age of 30 who have an appointment with several doctors, arrange by date of birth
    /// </summary>
    [Fact]
    public void SixthRequest()
    {
        var patientList = _fixture.CreateDefaultPatients;
        var receptionList = _fixture.CreateDefaultReceptions;
        var requestPatientsAndSeveralDoctors = (from patient in patientList
                                                join reception in receptionList on patient.Id equals reception.PatientId
                                                where patient.Receptions.Count > 1
                                                select new
                                                {
                                                    count = patient.Receptions.Count,
                                                    fio = patient.Fio,
                                                    birthDate = patient.BirthDate
                                                }).ToList();
        var requestOlderPatients = (from patient in requestPatientsAndSeveralDoctors
                                    where DateTime.Today.Year - patient.birthDate.Year > 30
                                    select patient).Distinct().ToList();
        Assert.Equal(patientList[1].Fio, requestOlderPatients[0].fio);
    }
}