using Policlinic;
using System.Security.Cryptography;

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
                                 select doctor.Fio).ToList();
        Assert.Equal(doctorList[1].Fio, requestDoctorList[0]);
    }
    /// <summary>
    /// Display information about all patients who have made an appointment with the specified doctor, arrange by name
    /// </summary>
    [Fact]
    public void SecondRequest()
    {
        var patientList = _fixture.CreateDefaultPatients;
        var doctorList = _fixture.CreateDefaultDoctors;
        var requestPatientList = (from patient in patientList
                                  join doctor in doctorList on patient.Receptions[0].IdReception equals doctor.Receptions[0].IdReception
                                  select patient).ToList();
        Assert.Equal(patientList[0], requestPatientList[0]);
    }
    /// <summary>
    /// Display information about currently healthy patients
    /// </summary>
    [Fact]
    public void ThirdRequest()
    {
        var receptionList = _fixture.CreateDefaultReceptions;
        var requestHealthyPatientList = (from reception in receptionList
                                         where reception.Status == "Healthy"
                                         select reception.Patient).ToList();
        Assert.Equal(receptionList[1].Patient, requestHealthyPatientList[0]);
        Assert.Equal(receptionList[2].Patient, requestHealthyPatientList[1]);
    }
    /// <summary>
    /// Display information about the number of patient appointments by doctors for the last month
    /// </summary>
    [Fact]
    public void FourthRequest()
    {
        var patientList = _fixture.CreateDefaultPatients;
        var doctorList = _fixture.CreateDefaultDoctors;
        var requestCountReceptionsInOneMonth = (from doctor in doctorList
                                                where doctor.Receptions[0].DateAndTime > new DateTime(2023, 1, 31) && doctor.Receptions[0].DateAndTime < new DateTime(2023, 3, 1)
                                                orderby doctor.Receptions.Count descending
                                                select doctor).ToList();
        Assert.Equal(doctorList[0], requestCountReceptionsInOneMonth[0]);
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
        var requestOlderPatients = (from patient in patientList
                                    where DateTime.Today.Year - patient.BirthDate.Year > 30 && patient.Receptions.Count > 1
                                    select patient).ToList();
        Assert.Equal(patientList[1], requestOlderPatients[0]);
    }
}