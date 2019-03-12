using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class vs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidato",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(nullable: false),
                    nome = table.Column<string>(nullable: false),
                    skype = table.Column<string>(nullable: false),
                    telefone = table.Column<string>(nullable: false),
                    linkedin = table.Column<string>(nullable: true),
                    cidade = table.Column<string>(nullable: false),
                    uf = table.Column<string>(nullable: false),
                    portifolio = table.Column<string>(nullable: true),
                    pretencao_salarial_hora = table.Column<double>(nullable: false),
                    nota_outros = table.Column<string>(nullable: true),
                    link_crud = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "disp_horas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disp_horas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "disp_periodo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disp_periodo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "linguagem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_linguagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cand_disp_Horas",
                columns: table => new
                {
                    CandidatoId = table.Column<long>(nullable: false),
                    DisponibilidadeHorasId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cand_disp_Horas", x => new { x.CandidatoId, x.DisponibilidadeHorasId });
                    table.ForeignKey(
                        name: "FK_cand_disp_Horas_candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cand_disp_Horas_disp_horas_DisponibilidadeHorasId",
                        column: x => x.DisponibilidadeHorasId,
                        principalTable: "disp_horas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cand_disp_periodo",
                columns: table => new
                {
                    CandidatoId = table.Column<long>(nullable: false),
                    DisponibilidadePeriodoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cand_disp_periodo", x => new { x.CandidatoId, x.DisponibilidadePeriodoId });
                    table.ForeignKey(
                        name: "FK_cand_disp_periodo_candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cand_disp_periodo_disp_periodo_DisponibilidadePeriodoId",
                        column: x => x.DisponibilidadePeriodoId,
                        principalTable: "disp_periodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cand_linguagem",
                columns: table => new
                {
                    CandidatoId = table.Column<long>(nullable: false),
                    LinguagemId = table.Column<long>(nullable: false),
                    Nota = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cand_linguagem", x => new { x.CandidatoId, x.LinguagemId });
                    table.ForeignKey(
                        name: "FK_cand_linguagem_candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cand_linguagem_linguagem_LinguagemId",
                        column: x => x.LinguagemId,
                        principalTable: "linguagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "disp_horas",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1L, "Up to 4 hours per day / Até 4 horas por dia" },
                    { 2L, "4 to 6 hours per day / De 4 á 6 horas por dia" },
                    { 3L, "6 to 8 hours per day /De 6 á 8 horas por dia" },
                    { 4L, "Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?" },
                    { 5L, "Only weekends / Apenas finais de semana" }
                });

            migrationBuilder.InsertData(
                table: "disp_periodo",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1L, "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)" },
                    { 2L, "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)" },
                    { 3L, "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)" },
                    { 4L, "Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)" },
                    { 5L, "Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)" }
                });

            migrationBuilder.InsertData(
                table: "linguagem",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 18L, "Cake" },
                    { 19L, "Django" },
                    { 20L, "Majento" },
                    { 21L, "PHP" },
                    { 22L, "Vue" },
                    { 23L, "Wordpress" },
                    { 28L, "Salesforce" },
                    { 25L, "Ruby" },
                    { 26L, "MS SQL Server" },
                    { 27L, "My SQL Server" },
                    { 17L, "NodeJS" },
                    { 29L, "Photoshop" },
                    { 30L, "Illustrator" },
                    { 24L, "Phyton" },
                    { 16L, "C#" },
                    { 11L, "Angular" },
                    { 14L, "Asp.Net WebForm" },
                    { 13L, "Asp.Net MVC" },
                    { 12L, "Java" },
                    { 31L, "SEO" },
                    { 10L, "AngularJs 1.*" },
                    { 9L, "Jquery" },
                    { 8L, "Bootstrap" },
                    { 7L, "CSS" },
                    { 6L, "HTML" },
                    { 5L, "IOS" },
                    { 4L, "Android" },
                    { 3L, "React Native" },
                    { 2L, "ReactJS" },
                    { 1L, "Ionic" },
                    { 15L, "C" },
                    { 32L, "Laravel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cand_disp_Horas_DisponibilidadeHorasId",
                table: "cand_disp_Horas",
                column: "DisponibilidadeHorasId");

            migrationBuilder.CreateIndex(
                name: "IX_cand_disp_periodo_DisponibilidadePeriodoId",
                table: "cand_disp_periodo",
                column: "DisponibilidadePeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_cand_linguagem_LinguagemId",
                table: "cand_linguagem",
                column: "LinguagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cand_disp_Horas");

            migrationBuilder.DropTable(
                name: "cand_disp_periodo");

            migrationBuilder.DropTable(
                name: "cand_linguagem");

            migrationBuilder.DropTable(
                name: "disp_horas");

            migrationBuilder.DropTable(
                name: "disp_periodo");

            migrationBuilder.DropTable(
                name: "candidato");

            migrationBuilder.DropTable(
                name: "linguagem");
        }
    }
}
