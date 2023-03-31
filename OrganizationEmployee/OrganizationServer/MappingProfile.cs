using AutoMapper;
using EmployeeDomain;
using OrganizationServer.DTO;

namespace OrganizationServer;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WorkshopDTO, Workshop>().ReverseMap();
        CreateMap<DepartmentDTO, Department>().ReverseMap();
        CreateMap<DepartmentEmployeeDTO, DepartmentEmployee>().ReverseMap();
        CreateMap<EmployeeOccupationDTO, EmployeeOccupation>().ReverseMap();
        CreateMap<EmployeeDTO, Employee>().ReverseMap();
        CreateMap<VoucherTypeDTO, VoucherType>().ReverseMap();
        CreateMap<VacationVoucherDTO, VacationVoucher>().ReverseMap();
        CreateMap<OccupationDTO, Occupation>().ReverseMap();
        CreateMap<EmployeeVacationVoucherDTO, EmployeeVacationVoucher>().ReverseMap();
    }
}
