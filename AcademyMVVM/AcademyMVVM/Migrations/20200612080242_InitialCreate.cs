using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyMVVM.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    NameSubject = table.Column<string>(nullable: true),
                    DniStudent = table.Column<string>(nullable: true),
                    DateEnrolment = table.Column<DateTime>(nullable: true),
                    ChairNumber = table.Column<int>(nullable: true),
                    SubjectsId = table.Column<Guid>(nullable: true),
                    StudentsId = table.Column<Guid>(nullable: true),
                    Exams_NameSubject = table.Column<string>(nullable: true),
                    Exams_DniStudent = table.Column<string>(nullable: true),
                    DateExam = table.Column<DateTime>(nullable: true),
                    Mark = table.Column<double>(nullable: true),
                    Exams_SubjectsId = table.Column<Guid>(nullable: true),
                    Exams_StudentsId = table.Column<Guid>(nullable: true),
                    Dni = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Teacher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_Exams_StudentsId",
                        column: x => x.Exams_StudentsId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_Exams_SubjectsId",
                        column: x => x.Exams_SubjectsId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_StudentsId",
                table: "Entity",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_SubjectsId",
                table: "Entity",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_Exams_StudentsId",
                table: "Entity",
                column: "Exams_StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_Exams_SubjectsId",
                table: "Entity",
                column: "Exams_SubjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
