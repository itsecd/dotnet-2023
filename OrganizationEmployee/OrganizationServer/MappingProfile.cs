using AutoMapper;
using OrganizationEmployee.EmployeeDomain;
using OrganizationEmployee.Server.Dto;

namespace OrganizationEmployee.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WorkshopDto, Workshop>().ReverseMap();
        CreateMap<DepartmentDto, Department>().ReverseMap();
        CreateMap<DepartmentEmployeeDto, DepartmentEmployee>().ReverseMap();
        CreateMap<EmployeeOccupationDto, EmployeeOccupation>().ReverseMap();
        CreateMap<EmployeeDto, Employee>().ReverseMap();
        CreateMap<VoucherTypeDto, VoucherType>().ReverseMap();
        CreateMap<VacationVoucherDto, VacationVoucher>().ReverseMap();
        CreateMap<OccupationDto, Occupation>().ReverseMap();
        CreateMap<EmployeeVacationVoucherDto, EmployeeVacationVoucher>().ReverseMap();
    }
}
