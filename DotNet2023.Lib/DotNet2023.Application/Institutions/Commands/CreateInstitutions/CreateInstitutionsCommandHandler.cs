using DotNet2023.Application.Interfaces;
using DotNet2023.Domain.Organization;
using MediatR;

namespace DotNet2023.Application.Institutions.Commands.CreateInstitutions;
public class CreateInstitutionsCommandHandler : IRequestHandler<CreateInstitutionsCommand>
{
    private readonly IDbContext _dbContext;

    public CreateInstitutionsCommandHandler(IDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(CreateInstitutionsCommand request, CancellationToken cancellationToken)
    {
        var institution = new HigherEducationInstitution()
        {
            FullName = request.FullName,
            Initials = request.Initials,
            LegalAddress = request.LegalAddress,
            BuildingProperty = request.BuildingProperty,
            InstitutionalProperty = request.InstitutionalProperty,
            RegistrationNumber = request.RegistrationNumber,
            Phone = request.Phone,
            Email = request.Email,
        };

        await _dbContext.Institutes.AddAsync(institution, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        // TODO check for Task<string>, where string is Id new object
    }
}
