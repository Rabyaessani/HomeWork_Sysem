using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeChemistryAPI.Migrations
{
    public partial class SQLiteInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    content = table.Column<string>(type: "TEXT", nullable: true),
                    cover_picture = table.Column<byte[]>(type: "BLOB", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    published_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    updated_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    ispublish = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category_name = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    published_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    updated_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    ispublish = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    cover_picture = table.Column<byte[]>(type: "BLOB", nullable: true),
                    content = table.Column<string>(type: "TEXT", nullable: true),
                    youtube_video = table.Column<string>(type: "TEXT", nullable: true),
                    category_id = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    published_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    updated_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    ispublish = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MCQs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    published_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    updated_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    ispublish = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCQs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    question = table.Column<string>(type: "TEXT", nullable: true),
                    option_a = table.Column<string>(type: "TEXT", nullable: true),
                    option_b = table.Column<string>(type: "TEXT", nullable: true),
                    option_c = table.Column<string>(type: "TEXT", nullable: true),
                    option_d = table.Column<string>(type: "TEXT", nullable: true),
                    correct_option = table.Column<char>(type: "TEXT", nullable: false),
                    mcq_id = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    published_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    updated_by_id = table.Column<int>(type: "INTEGER", nullable: true),
                    ispublish = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "MCQs");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
