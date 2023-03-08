using EmployeeDomain;

namespace EmployeeDomainTests;
public class EmployeeFixture
{

    public List<Workshop> WorkshopFixture
    {
        get
        {
            return new List<Workshop>
            {
                new Workshop {
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
        }

    }

    public List<Department> DepartmentFixture
    {
        get 
        {
            return new List<Department>
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
        }
    }
}
