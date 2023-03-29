using EmployeeDomain;

namespace OrganizationServer;

public class OrganizationRepository
{
    public List<Workshop> Workshops = new()
    {
        new Workshop
        {
            Name = "Ленинский цех",
            Id = 1,
            Employees = new List<Employee>()
        },
        new Workshop
        {
            Name = "Производственный цех",
            Id = 2,
            Employees = new List<Employee>()
        },
        new Workshop {
            Name = "Восточный цех",
            Id = 3,
            Employees = new List<Employee>()
        },
        new Workshop
        {
            Name = "Волжский цех",
            Id = 4,
            Employees = new List<Employee>()
        },
        new Workshop
        {
            Name = "Новоспасский цех",
            Id = 5,
            Employees = new List<Employee>()
        },
        new Workshop
        {
            Name = "Ульяновский цех",
            Id = 6,
            Employees = new List<Employee>()
        }
    };

    public List<Department> Departments = new()
    {
        new Department
        {
            Name = "Отдел ИБ",
            Id = 1
        },
        new Department
        {
            Name = "Отдел программирования",
            Id = 2
        },
        new Department
        {
            Name = "Отдел кадров",
            Id = 3
        },
        new Department
        {
            Name = "Отдел менеджмента",
            Id = 4
        },
        new Department
        {
            Name = "Отдел бухгалтерии",
            Id = 5
        },
        new Department
        {
            Name = "Отдел аналитики данных",
            Id = 6
        },
        new Department
        {
            Name = "Отдел тестирования",
            Id = 7
        },
        new Department
        {
            Name = "Технический отдел",
            Id = 8
        },
        new Department
        {
            Name = "Отдел логистики",
            Id = 9
        },
        new Department
        {
            Name = "Отдел снабжения и закупок",
            Id = 10
        }
    };

    public List<VoucherType> VoucherTypes = new()
    {
        new VoucherType
        {
            Name = "Санаторий",
            Id = 0,
            VacationVouchers = new List<VacationVoucher>()
        },
        new VoucherType
        {
            Name = "Дом отдыха",
            Id = 1,
            VacationVouchers = new List<VacationVoucher>()
        },
        new VoucherType
        {
            Name = "Пионерский лагерь предприятия",
            Id = 2,
            VacationVouchers = new List<VacationVoucher>()
        }
    };

    public List<VacationVoucher> VacationVouchers = new()
    {
        new VacationVoucher
        {
            Id = 1,
            VoucherType = null,
            IssueDate = new DateTime(2022, 3, 22),
            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
        },
        new VacationVoucher
        {
            Id = 2,
            VoucherType = null,
            IssueDate = new DateTime(2022, 5, 12),
            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
        },
        new VacationVoucher
        {
            Id = 3,
            VoucherType = null,
            IssueDate = new DateTime(2020, 1, 5),
            EmployeeVacationVouchers = new List<EmployeeVacationVoucher>()
        }
    };
}
