using AutoMapper;
using EmployeeDomain;
using OrganizationServer.DTO;

namespace OrganizationServer;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WorkshopDTO, Workshop>();
        CreateMap<DepartmentDTO, Department>();
        CreateMap<VoucherTypeDTO, VoucherType>();
        CreateMap<VacationVoucherDTO, VacationVoucher>();
        CreateMap<OccupationDTO, Occupation>();
    }
}
