using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet2023.WebApi.Migrations;

public partial class __init : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Specialties",
            columns: table => new
            {
                Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Title = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                StudyFormat = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Specialties", x => x.Code);
            });

        migrationBuilder.CreateTable(
            name: "BasePerson",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                Surname = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                Patronymic = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                BirthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                Email = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ScienceDegree = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                Rank = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                IdOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                JobTitle = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                Salary = table.Column<double>(type: "float", nullable: true),
                IdGroup = table.Column<string>(type: "nvarchar(450)", nullable: true),
                IdSpeciality = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                SpecialityCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BasePerson", x => x.Id);
                table.ForeignKey(
                    name: "FK_BasePerson_Specialties_SpecialityCode",
                    column: x => x.SpecialityCode,
                    principalTable: "Specialties",
                    principalColumn: "Code");
            });

        migrationBuilder.CreateTable(
            name: "Organization",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                FullName = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                Initials = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                LegalAddress = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                RegistrationNumber = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                Email = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                IdRector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RectorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                InstitutionalProperty = table.Column<int>(type: "int", nullable: true),
                BuildingProperty = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Organization", x => x.Id);
                table.ForeignKey(
                    name: "FK_Organization_BasePerson_RectorId",
                    column: x => x.RectorId,
                    principalTable: "BasePerson",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "BaseSection",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                Email = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                IdHeadOfDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                HeadOfDepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                IdFaculty = table.Column<string>(type: "nvarchar(450)", nullable: true),
                IdInstitute = table.Column<string>(type: "nvarchar(450)", nullable: true),
                IdDean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DeanId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                Faculty_IdInstitute = table.Column<string>(type: "nvarchar(450)", nullable: true),
                IdSpeciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                SpecialityCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                IdDepartment = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BaseSection", x => x.Id);
                table.ForeignKey(
                    name: "FK_BaseSection_BasePerson_DeanId",
                    column: x => x.DeanId,
                    principalTable: "BasePerson",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_BaseSection_BasePerson_HeadOfDepartmentId",
                    column: x => x.HeadOfDepartmentId,
                    principalTable: "BasePerson",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_BaseSection_BaseSection_IdDepartment",
                    column: x => x.IdDepartment,
                    principalTable: "BaseSection",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_BaseSection_BaseSection_IdFaculty",
                    column: x => x.IdFaculty,
                    principalTable: "BaseSection",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_BaseSection_Organization_Faculty_IdInstitute",
                    column: x => x.Faculty_IdInstitute,
                    principalTable: "Organization",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_BaseSection_Organization_IdInstitute",
                    column: x => x.IdInstitute,
                    principalTable: "Organization",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_BaseSection_Specialties_SpecialityCode",
                    column: x => x.SpecialityCode,
                    principalTable: "Specialties",
                    principalColumn: "Code");
            });

        migrationBuilder.CreateTable(
            name: "InstituteSpecialties",
            columns: table => new
            {
                Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                IdSpeciality = table.Column<string>(type: "nvarchar(450)", nullable: true),
                IdHigherEducationInstitution = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InstituteSpecialties", x => x.Key);
                table.ForeignKey(
                    name: "FK_InstituteSpecialties_Organization_IdHigherEducationInstitution",
                    column: x => x.IdHigherEducationInstitution,
                    principalTable: "Organization",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_InstituteSpecialties_Specialties_IdSpeciality",
                    column: x => x.IdSpeciality,
                    principalTable: "Specialties",
                    principalColumn: "Code");
            });

        migrationBuilder.CreateIndex(
            name: "IX_BasePerson_IdGroup",
            table: "BasePerson",
            column: "IdGroup");

        migrationBuilder.CreateIndex(
            name: "IX_BasePerson_SpecialityCode",
            table: "BasePerson",
            column: "SpecialityCode");

        migrationBuilder.CreateIndex(
            name: "IX_BaseSection_DeanId",
            table: "BaseSection",
            column: "DeanId");

        migrationBuilder.CreateIndex(
            name: "IX_BaseSection_Faculty_IdInstitute",
            table: "BaseSection",
            column: "Faculty_IdInstitute");

        migrationBuilder.CreateIndex(
            name: "IX_BaseSection_HeadOfDepartmentId",
            table: "BaseSection",
            column: "HeadOfDepartmentId");

        migrationBuilder.CreateIndex(
            name: "IX_BaseSection_IdDepartment",
            table: "BaseSection",
            column: "IdDepartment");

        migrationBuilder.CreateIndex(
            name: "IX_BaseSection_IdFaculty",
            table: "BaseSection",
            column: "IdFaculty");

        migrationBuilder.CreateIndex(
            name: "IX_BaseSection_IdInstitute",
            table: "BaseSection",
            column: "IdInstitute");

        migrationBuilder.CreateIndex(
            name: "IX_BaseSection_SpecialityCode",
            table: "BaseSection",
            column: "SpecialityCode");

        migrationBuilder.CreateIndex(
            name: "IX_InstituteSpecialties_IdHigherEducationInstitution",
            table: "InstituteSpecialties",
            column: "IdHigherEducationInstitution");

        migrationBuilder.CreateIndex(
            name: "IX_InstituteSpecialties_IdSpeciality",
            table: "InstituteSpecialties",
            column: "IdSpeciality");

        migrationBuilder.CreateIndex(
            name: "IX_Organization_RectorId",
            table: "Organization",
            column: "RectorId");

        migrationBuilder.AddForeignKey(
            name: "FK_BasePerson_BaseSection_IdGroup",
            table: "BasePerson",
            column: "IdGroup",
            principalTable: "BaseSection",
            principalColumn: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_BasePerson_BaseSection_IdGroup",
            table: "BasePerson");

        migrationBuilder.DropTable(
            name: "InstituteSpecialties");

        migrationBuilder.DropTable(
            name: "BaseSection");

        migrationBuilder.DropTable(
            name: "Organization");

        migrationBuilder.DropTable(
            name: "BasePerson");

        migrationBuilder.DropTable(
            name: "Specialties");
    }
}
