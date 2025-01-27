using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DNC.ProjectAudit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auditor");

            migrationBuilder.EnsureSchema(
                name: "AuditQuestionnaire");

            migrationBuilder.EnsureSchema(
                name: "CEO");

            migrationBuilder.EnsureSchema(
                name: "MultipleChoiceQuestion");

            migrationBuilder.EnsureSchema(
                name: "OpenQuestion");

            migrationBuilder.EnsureSchema(
                name: "ProjectManager");

            migrationBuilder.EnsureSchema(
                name: "SelectListQuestion");

            migrationBuilder.EnsureSchema(
                name: "Supervisor");

            migrationBuilder.CreateTable(
                name: "tblAuditor",
                schema: "Auditor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuditor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCEO",
                schema: "CEO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    AssistantPhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCEO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAuditQuestionnaire",
                schema: "AuditQuestionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubmissionDeadline = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubmittedBySupervisorsText = table.Column<string>(type: "nvarchar(2048)", nullable: true),
                    ApprovedByProjetManagerId = table.Column<int>(type: "int", nullable: false),
                    IsStarted = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    QuestionnaireAuditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuditQuestionnaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAuditQuestionnaire_tblAuditor_QuestionnaireAuditorId",
                        column: x => x.QuestionnaireAuditorId,
                        principalSchema: "Auditor",
                        principalTable: "tblAuditor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblMultipleChoiceQuestion",
                schema: "MultipleChoiceQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(2048)", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    IsDisplay = table.Column<bool>(type: "bit", nullable: true),
                    PriorityIndication = table.Column<int>(type: "int", nullable: false),
                    QuestionAuditQuestionnaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMultipleChoiceQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblMultipleChoiceQuestion_tblAuditQuestionnaire_QuestionAuditQuestionnaireId",
                        column: x => x.QuestionAuditQuestionnaireId,
                        principalSchema: "AuditQuestionnaire",
                        principalTable: "tblAuditQuestionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOpenQuestion",
                schema: "OpenQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(2048)", nullable: true),
                    IsDisplay = table.Column<bool>(type: "bit", nullable: true),
                    PriorityIndication = table.Column<int>(type: "int", nullable: false),
                    QuestionAuditQuestionnaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOpenQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOpenQuestion_tblAuditQuestionnaire_QuestionAuditQuestionnaireId",
                        column: x => x.QuestionAuditQuestionnaireId,
                        principalSchema: "AuditQuestionnaire",
                        principalTable: "tblAuditQuestionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProjectManager",
                schema: "ProjectManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ProjectManagerAuditQuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjectManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProjectManager_tblAuditQuestionnaire_ProjectManagerAuditQuestionnaireId",
                        column: x => x.ProjectManagerAuditQuestionnaireId,
                        principalSchema: "AuditQuestionnaire",
                        principalTable: "tblAuditQuestionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSelectListQuestion",
                schema: "SelectListQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(1024)", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(2048)", nullable: true),
                    IsDisplay = table.Column<bool>(type: "bit", nullable: true),
                    PriorityIndication = table.Column<int>(type: "int", nullable: false),
                    QuestionAuditQuestionnaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSelectListQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSelectListQuestion_tblAuditQuestionnaire_QuestionAuditQuestionnaireId",
                        column: x => x.QuestionAuditQuestionnaireId,
                        principalSchema: "AuditQuestionnaire",
                        principalTable: "tblAuditQuestionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSupervisor",
                schema: "Supervisor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    SupervisorProjectManagerId = table.Column<int>(type: "int", nullable: false),
                    SupervisorAuditQuestionnaireId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSupervisor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSupervisor_tblAuditQuestionnaire_SupervisorAuditQuestionnaireId",
                        column: x => x.SupervisorAuditQuestionnaireId,
                        principalSchema: "AuditQuestionnaire",
                        principalTable: "tblAuditQuestionnaire",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblSupervisor_tblProjectManager_SupervisorProjectManagerId",
                        column: x => x.SupervisorProjectManagerId,
                        principalSchema: "ProjectManager",
                        principalTable: "tblProjectManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "AuditQuestionnaire",
                table: "tblAuditQuestionnaire",
                columns: new[] { "Id", "ApprovedByProjetManagerId", "CreatedBy", "CreatedDate", "DeletedBy", "Description", "IsCompleted", "IsStarted", "Name", "QuestionnaireAuditorId", "Region", "SubmissionDeadline", "SubmittedBySupervisorsText", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(2024, 12, 29, 12, 31, 35, 132, DateTimeKind.Local).AddTicks(5020), 0, "DNC, Project name, Region", false, false, "DNC_BlueLine_Brussele", null, "Brussels", new DateTime(2025, 1, 5, 12, 31, 35, 132, DateTimeKind.Local).AddTicks(5066), null, 0 },
                    { 2, 0, 1, new DateTime(2024, 12, 29, 12, 31, 35, 132, DateTimeKind.Local).AddTicks(5071), 0, "DNC, Project name, Region", false, false, "DNC_RedLine_Brussele", null, "Antwerp", new DateTime(2025, 1, 5, 12, 31, 35, 132, DateTimeKind.Local).AddTicks(5072), null, 0 }
                });

            migrationBuilder.InsertData(
                schema: "Auditor",
                table: "tblAuditor",
                columns: new[] { "Id", "Email", "FirstName", "IsActive", "LastName", "MobilePhone", "OfficePhone", "Role" },
                values: new object[] { 2, "janjanssen@dnc.com", "Jan", true, "Janssen", "+32488222333", "+32222222", "Auditor" });

            migrationBuilder.InsertData(
                schema: "CEO",
                table: "tblCEO",
                columns: new[] { "Id", "AssistantPhone", "Email", "FirstName", "IsActive", "LastName", "MobilePhone", "OfficePhone", "Phone", "Role" },
                values: new object[] { 1, "+32111999", "guningdeng@dnc.com", "Guning", true, "Deng", "+32486333888", "+32111111", "+32222222", "CEO" });

            migrationBuilder.InsertData(
                schema: "MultipleChoiceQuestion",
                table: "tblMultipleChoiceQuestion",
                columns: new[] { "Id", "AnswerText", "IsDisplay", "OptionText", "PriorityIndication", "QuestionAuditQuestionnaireId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "NoValue", true, "BBA;BASF;HoutVlaanderen", 1, 1, "Materiaalleverancier voor dit project:" },
                    { 2, "NoValue", true, "EU;België;Antwerpen;Brussel;Gent;Luik;Andere regions", 1, 1, "De regio waar de materiaalleverancier van dit project gevestigd is" }
                });

            migrationBuilder.InsertData(
                schema: "OpenQuestion",
                table: "tblOpenQuestion",
                columns: new[] { "Id", "AnswerText", "IsDisplay", "PriorityIndication", "QuestionAuditQuestionnaireId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "NoValue", true, 1, 1, "Beschrijf uw missie." },
                    { 2, "NoValue", true, 1, 1, "Beschrijf het project." }
                });

            migrationBuilder.InsertData(
                schema: "ProjectManager",
                table: "tblProjectManager",
                columns: new[] { "Id", "Email", "FirstName", "IsActive", "LastName", "MobilePhone", "OfficePhone", "ProjectManagerAuditQuestionnaireId", "Region", "Role" },
                values: new object[,]
                {
                    { 3, "brunopeeters@dnc.com", "Bruno", true, "Peeters", "+32486111333", "+32333222", 1, "Brussels", "ProjectManager" },
                    { 4, "aanvananders@dnc.com", "Aan", true, "van Anders", "+32486111555", "+32333555", 2, "Antwerp", "ProjectManager" }
                });

            migrationBuilder.InsertData(
                schema: "SelectListQuestion",
                table: "tblSelectListQuestion",
                columns: new[] { "Id", "AnswerText", "IsDisplay", "OptionText", "PriorityIndication", "QuestionAuditQuestionnaireId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "NoValue", true, "S235;S275;S355", 1, 1, "Staalsoort gebruikt in project:" },
                    { 2, "NoValue", true, "Wagen;Vrachtwagen;Aanhangwagen;Bus", 1, 1, "Type transportvoertuig dat in het project wordt gebruikt:" }
                });

            migrationBuilder.InsertData(
                schema: "Supervisor",
                table: "tblSupervisor",
                columns: new[] { "Id", "Email", "FirstName", "IsActive", "LastName", "MobilePhone", "OfficePhone", "Region", "Role", "SupervisorAuditQuestionnaireId", "SupervisorProjectManagerId" },
                values: new object[] { -2, "christbrown@dnc.com", "Christ", true, "Brown", "+32486555222", "+32555333", "Brussels", "Supervisor", null, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditor_Id",
                schema: "Auditor",
                table: "tblAuditor",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditQuestionnaire_Name",
                schema: "AuditQuestionnaire",
                table: "tblAuditQuestionnaire",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditQuestionnaire_QuestionnaireAuditorId",
                schema: "AuditQuestionnaire",
                table: "tblAuditQuestionnaire",
                column: "QuestionnaireAuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCEO_Id",
                schema: "CEO",
                table: "tblCEO",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblMultipleChoiceQuestion_Id",
                schema: "MultipleChoiceQuestion",
                table: "tblMultipleChoiceQuestion",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblMultipleChoiceQuestion_QuestionAuditQuestionnaireId",
                schema: "MultipleChoiceQuestion",
                table: "tblMultipleChoiceQuestion",
                column: "QuestionAuditQuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOpenQuestion_Id",
                schema: "OpenQuestion",
                table: "tblOpenQuestion",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblOpenQuestion_QuestionAuditQuestionnaireId",
                schema: "OpenQuestion",
                table: "tblOpenQuestion",
                column: "QuestionAuditQuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProjectManager_Id",
                schema: "ProjectManager",
                table: "tblProjectManager",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblProjectManager_ProjectManagerAuditQuestionnaireId",
                schema: "ProjectManager",
                table: "tblProjectManager",
                column: "ProjectManagerAuditQuestionnaireId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSelectListQuestion_Id",
                schema: "SelectListQuestion",
                table: "tblSelectListQuestion",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSelectListQuestion_QuestionAuditQuestionnaireId",
                schema: "SelectListQuestion",
                table: "tblSelectListQuestion",
                column: "QuestionAuditQuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupervisor_Id",
                schema: "Supervisor",
                table: "tblSupervisor",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSupervisor_SupervisorAuditQuestionnaireId",
                schema: "Supervisor",
                table: "tblSupervisor",
                column: "SupervisorAuditQuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupervisor_SupervisorProjectManagerId",
                schema: "Supervisor",
                table: "tblSupervisor",
                column: "SupervisorProjectManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCEO",
                schema: "CEO");

            migrationBuilder.DropTable(
                name: "tblMultipleChoiceQuestion",
                schema: "MultipleChoiceQuestion");

            migrationBuilder.DropTable(
                name: "tblOpenQuestion",
                schema: "OpenQuestion");

            migrationBuilder.DropTable(
                name: "tblSelectListQuestion",
                schema: "SelectListQuestion");

            migrationBuilder.DropTable(
                name: "tblSupervisor",
                schema: "Supervisor");

            migrationBuilder.DropTable(
                name: "tblProjectManager",
                schema: "ProjectManager");

            migrationBuilder.DropTable(
                name: "tblAuditQuestionnaire",
                schema: "AuditQuestionnaire");

            migrationBuilder.DropTable(
                name: "tblAuditor",
                schema: "Auditor");
        }
    }
}
