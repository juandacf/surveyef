using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories_catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "Now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "Now()"),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories_catalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "options_response",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    optiontext = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options_response", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    componenthtml = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    ComponentReact = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    instruction = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "category_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    catalogoptions_id = table.Column<int>(type: "integer", nullable: false),
                    categoriesoptions_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_options", x => x.id);
                    table.ForeignKey(
                        name: "fk_categoryoptions_categoriescatalog",
                        column: x => x.catalogoptions_id,
                        principalTable: "categories_catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_categoryoptions_optionsresponse",
                        column: x => x.categoriesoptions_id,
                        principalTable: "options_response",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chapters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    survey_id = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    componenthtml = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    componentreact = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    chapter_number = table.Column<string>(type: "varchar(50)", nullable: false),
                    chapter_title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapters", x => x.id);
                    table.ForeignKey(
                        name: "fk_chapters_survey",
                        column: x => x.survey_id,
                        principalTable: "surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sumary_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_survey = table.Column<int>(type: "int", nullable: false),
                    codenumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    idquestion = table.Column<int>(type: "int", nullable: false),
                    valuerta = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sumary_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_sumary_options_surveys_id_survey",
                        column: x => x.id_survey,
                        principalTable: "surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuestionNumber = table.Column<string>(type: "text", nullable: true),
                    ResponseType = table.Column<string>(type: "text", nullable: true),
                    CommentQuestion = table.Column<string>(type: "text", nullable: true),
                    Questiontext = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "chapters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sub_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    subquestion_id = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    subquestion_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    comment_subquestion = table.Column<string>(type: "text", nullable: true),
                    subquestiontext = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_sub_questions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OptionQuestions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    option_id = table.Column<int>(type: "integer", nullable: false),
                    optioncatalog_id = table.Column<int>(type: "integer", nullable: false),
                    optionquestion_id = table.Column<int>(type: "integer", nullable: false),
                    subquestion_id = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    comment_optionres = table.Column<string>(type: "text", nullable: true),
                    numberoption = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionQuestions", x => x.id);
                    table.ForeignKey(
                        name: "FK_OptionQuestions_CategoriesCatalog",
                        column: x => x.optioncatalog_id,
                        principalTable: "categories_catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionQuestions_OptionsResponse",
                        column: x => x.option_id,
                        principalTable: "options_response",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionQuestions_Questions",
                        column: x => x.optionquestion_id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionQuestions_SubQuestions",
                        column: x => x.subquestion_id,
                        principalTable: "sub_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_options_catalogoptions_id",
                table: "category_options",
                column: "catalogoptions_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_options_categoriesoptions_id",
                table: "category_options",
                column: "categoriesoptions_id");

            migrationBuilder.CreateIndex(
                name: "IX_chapters_survey_id",
                table: "chapters",
                column: "survey_id");

            migrationBuilder.CreateIndex(
                name: "IX_OptionQuestions_option_id",
                table: "OptionQuestions",
                column: "option_id");

            migrationBuilder.CreateIndex(
                name: "IX_OptionQuestions_optioncatalog_id",
                table: "OptionQuestions",
                column: "optioncatalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_OptionQuestions_optionquestion_id",
                table: "OptionQuestions",
                column: "optionquestion_id");

            migrationBuilder.CreateIndex(
                name: "IX_OptionQuestions_subquestion_id",
                table: "OptionQuestions",
                column: "subquestion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ChapterId",
                table: "Questions",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_sub_questions_QuestionId",
                table: "sub_questions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_sumary_options_id_survey",
                table: "sumary_options",
                column: "id_survey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category_options");

            migrationBuilder.DropTable(
                name: "OptionQuestions");

            migrationBuilder.DropTable(
                name: "sumary_options");

            migrationBuilder.DropTable(
                name: "categories_catalog");

            migrationBuilder.DropTable(
                name: "options_response");

            migrationBuilder.DropTable(
                name: "sub_questions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "chapters");

            migrationBuilder.DropTable(
                name: "surveys");
        }
    }
}
