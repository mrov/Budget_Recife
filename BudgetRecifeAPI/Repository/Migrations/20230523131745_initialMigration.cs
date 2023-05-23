using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    _id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ano_movimentacao = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    mes_movimentacao = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    orgao_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    orgao_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    unidade_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    unidade_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    categoria_economica_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    categoria_economica_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    grupo_despesa_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    grupo_despesa_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    modalidade_aplicacao_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    modalidade_aplicacao_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    elemento_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    elemento_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    subelemento_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    subelemento_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    funcao_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    funcao_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    subfuncao_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    subfuncao_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    programa_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    programa_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    acao_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    acao_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    fonte_recurso_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    fonte_recurso_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    empenho_ano = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    empenho_modalidade_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    empenho_modalidade_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    empenho_numero = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    subempenho = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    indicador_subempenho = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    credor_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    credor_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    modalidade_licitacao_codigo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    modalidade_licitacao_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    valor_empenhado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    valor_liquidado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    valor_pago = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x._id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");
        }
    }
}
