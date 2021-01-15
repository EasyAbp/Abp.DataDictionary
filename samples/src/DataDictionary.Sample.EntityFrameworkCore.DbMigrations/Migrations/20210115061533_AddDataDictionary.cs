using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataDictionary.Sample.Migrations
{
    public partial class AddDataDictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EasyAbpAbpDataDictionaryDataDictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DisplayText = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpAbpDataDictionaryDataDictionaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpAbpDataDictionaryDataDictionaryItems",
                columns: table => new
                {
                    DataDictionaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisplayText = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpAbpDataDictionaryDataDictionaryItems", x => new { x.Code, x.DataDictionaryId });
                    table.ForeignKey(
                        name: "FK_EasyAbpAbpDataDictionaryDataDictionaryItems_EasyAbpAbpDataDictionaryDataDictionaries_DataDictionaryId",
                        column: x => x.DataDictionaryId,
                        principalTable: "EasyAbpAbpDataDictionaryDataDictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpAbpDataDictionaryDataDictionaries_Code",
                table: "EasyAbpAbpDataDictionaryDataDictionaries",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpAbpDataDictionaryDataDictionaryItems_Code_DataDictionaryId",
                table: "EasyAbpAbpDataDictionaryDataDictionaryItems",
                columns: new[] { "Code", "DataDictionaryId" });

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpAbpDataDictionaryDataDictionaryItems_DataDictionaryId",
                table: "EasyAbpAbpDataDictionaryDataDictionaryItems",
                column: "DataDictionaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyAbpAbpDataDictionaryDataDictionaryItems");

            migrationBuilder.DropTable(
                name: "EasyAbpAbpDataDictionaryDataDictionaries");
        }
    }
}
