namespace PoliclinicTests;

public class PoliclinicTest : IClassFixture<PoliclinicTestFixture>
{
    private PoliclinicTestFixture _fixture;

    public PoliclinicTest(PoliclinicTestFixture fixture)
    {
        _fixture = fixture;
    }
    /// <summary>
    /// Вывести информацию о всех врачах, стаж работы которых не меньше 10 лет
    /// </summary>
    [Fact]
    public void FirstRequest()
    {
        var doctorList = _fixture.CreateDefaultDoctors();
        var requestDoctorList = (from doctor in doctorList
                                 where doctor.WorkExperience >= 10
                                 select doctor.FIO).ToList();
        Assert.Equal(doctorList[1].FIO, requestDoctorList[0]);
    }
    /// <summary>
    /// Вывести информацию о всех пациентах, записанных на прием к указанному врачу, упорядочить по ФИО
    /// </summary>
    [Fact]
    public void SecondRequest()
    {
        var receptionList = _fixture.CreateDefaultReceptions();
        var patientList = _fixture.CreateDefaultPatients();
        var doctorList = _fixture.CreateDefaultDoctors();
        var requestPatientList = (from patient in patientList
                                  join reception in receptionList on patient.Passport equals (reception.PassportPatient)
                                  join doctor in doctorList on reception.PassportDoctor equals (doctor.Passport)
                                  where doctor.FIO == "Иванов Иван Иванович" && doctor.FIO.Count() > 1
                                  orderby patient.FIO
                                  select patient.FIO).ToList();
        Assert.Equal("Белов Евгений Максимович", requestPatientList[0]);
        Assert.Equal("Иванов Петр Владимирович", requestPatientList[1]);
    }
    /// <summary>
    /// Вывести информацию о здоровых на настоящий момент пациентах
    /// </summary>
    [Fact]
    public void ThirdRequest()
    {
        var receptionList = _fixture.CreateDefaultReceptions();
        var requestHealthyPatientList = (from reception in receptionList
                                         where reception.Status == "Здоров"
                                         select reception.PassportPatient).ToList();
        Assert.Equal(receptionList[1].PassportPatient, requestHealthyPatientList[0]);
        Assert.Equal(receptionList[2].PassportPatient, requestHealthyPatientList[1]);
    }
    /// <summary>
    /// Вывести информацию о количестве приемов пациентов по врачам за последний месяц
    /// </summary>
    [Fact]
    public void FourthRequest()
    {
        var receptionList = _fixture.CreateDefaultReceptions();
        var requestCountReceptionsInOneMonth = (from reception in receptionList
                                                where reception.DateAndTime > new DateTime(2023, 1, 31)
                                                && reception.DateAndTime < new DateTime(2023, 3, 1) && reception.PassportDoctor == 1234567890
                                                select reception.IdReception).Count();
        Assert.Equal(2, requestCountReceptionsInOneMonth);
    }
    /// <summary>
    /// Вывести информацию о топ 5 наиболее распространенных заболеваниях среди пациентов
    /// </summary>
    [Fact]
    public void FifthRequest()
    {
        var receptionList = _fixture.CreateDefaultReceptions();
        var requestTopDiseases = (from reception in receptionList
                                  where reception.Conclution != ""
                                  orderby reception.Conclution.Count()
                                  select reception.Conclution).Take(5).ToList();
        Assert.Equal("Нервоз", requestTopDiseases[0]);
        Assert.Equal("Псориаз", requestTopDiseases[1]);
    }
    /// <summary>
    /// Вывести информацию о пациентах старше 30 лет, которые записаны на прием к нескольким врачам, упорядочить по дате рождения
    /// </summary>
    [Fact]
    public void SixthRequest()
    {
        var receptionList = _fixture.CreateDefaultReceptions();
        var patientList = _fixture.CreateDefaultPatients();
        var requestOlderPatients = (from patient in patientList
                                    join reception in receptionList on patient.Passport equals (reception.PassportPatient)
                                    where DateTime.Today.Year - patient.BirthDate.Year > 30 && reception.Status.Count() > 1
                                    orderby patient.BirthDate
                                    select patient.FIO).ToList();
        Assert.Equal("Белов Евгений Максимович", requestOlderPatients[0]);
    }
}