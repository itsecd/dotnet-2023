using AutoMapper;
using OrganizationEmployee.EmployeeDomain;
using OrganizationEmployee.Server.Dto;

namespace OrganizationEmployee.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PostWorkshopDto, Workshop>();
        CreateMap<Workshop, GetWorkshopDto>();
        CreateMap<PostDepartmentDto, Department>();
        CreateMap<Department, GetDepartmentDto>();
        CreateMap<PostVoucherTypeDto, VoucherType>();
        CreateMap<VoucherType, GetVoucherTypeDto>();

        CreateMap<PostOccupationDto, Occupation>();
        CreateMap<Occupation, GetOccupationDto>();

        CreateMap<PostDepartmentEmployeeDto, DepartmentEmployee>();
        CreateMap<DepartmentEmployee, GetDepartmentEmployeeDto>();
        CreateMap<Employee, GetEmployeeDto>();
        CreateMap<PostEmployeeDto, Employee>();
        CreateMap<PostEmployeeOccupationDto, EmployeeOccupation>();
        CreateMap<EmployeeOccupation, GetEmployeeOccupationDto>();
        CreateMap<VacationVoucher, GetVacationVoucherDto>();
        CreateMap<PostVacationVoucherDto, VacationVoucher>();

        CreateMap<PostEmployeeVacationVoucherDto, EmployeeVacationVoucher>();
        CreateMap<EmployeeVacationVoucher, GetEmployeeVacationVoucherDto>();
    }
}
