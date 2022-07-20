using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrame.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banco",
                columns: table => new
                {
                    codigo_banco = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    nombre_banco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    direccion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banco", x => x.codigo_banco);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cedula = table.Column<string>(type: "text", nullable: false),
                    tipo_doc = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    nombre_apellido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.cedula);
                });

            migrationBuilder.CreateTable(
                name: "cuenta",
                columns: table => new
                {
                    num_cta = table.Column<string>(type: "text", nullable: false),
                    id_cta = table.Column<string>(type: "text", nullable: false),
                    moneda = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    saldo = table.Column<double>(type: "double precision", nullable: false),
                    cedula_cliente = table.Column<string>(type: "text", nullable: false),
                    cod_banco = table.Column<string>(type: "character varying(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta", x => x.num_cta);
                    table.ForeignKey(
                        name: "FK_cuenta_banco_cod_banco",
                        column: x => x.cod_banco,
                        principalTable: "banco",
                        principalColumn: "codigo_banco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cuenta_cliente_cedula_cliente",
                        column: x => x.cedula_cliente,
                        principalTable: "cliente",
                        principalColumn: "cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transferencia",
                columns: table => new
                {
                    id_transaccion = table.Column<string>(type: "text", nullable: false),
                    cedula_cliente = table.Column<string>(type: "text", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    monto = table.Column<float>(type: "real", nullable: false),
                    estado = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    num_cta = table.Column<string>(type: "text", nullable: false),
                    num_cta_destino = table.Column<string>(type: "text", nullable: false),
                    cod_banco_origen = table.Column<string>(type: "character varying(8)", nullable: false),
                    cod_banco_destino = table.Column<string>(type: "character varying(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transferencia", x => x.id_transaccion);
                    table.ForeignKey(
                        name: "FK_transferencia_banco_cod_banco_destino",
                        column: x => x.cod_banco_destino,
                        principalTable: "banco",
                        principalColumn: "codigo_banco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transferencia_banco_cod_banco_origen",
                        column: x => x.cod_banco_origen,
                        principalTable: "banco",
                        principalColumn: "codigo_banco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transferencia_cuenta_num_cta",
                        column: x => x.num_cta,
                        principalTable: "cuenta",
                        principalColumn: "num_cta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transferencia_cuenta_num_cta_destino",
                        column: x => x.num_cta_destino,
                        principalTable: "cuenta",
                        principalColumn: "num_cta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_cedula_cliente",
                table: "cuenta",
                column: "cedula_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_cod_banco",
                table: "cuenta",
                column: "cod_banco");

            migrationBuilder.CreateIndex(
                name: "IX_transferencia_cod_banco_destino",
                table: "transferencia",
                column: "cod_banco_destino");

            migrationBuilder.CreateIndex(
                name: "IX_transferencia_cod_banco_origen",
                table: "transferencia",
                column: "cod_banco_origen");

            migrationBuilder.CreateIndex(
                name: "IX_transferencia_num_cta",
                table: "transferencia",
                column: "num_cta");

            migrationBuilder.CreateIndex(
                name: "IX_transferencia_num_cta_destino",
                table: "transferencia",
                column: "num_cta_destino");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transferencia");

            migrationBuilder.DropTable(
                name: "cuenta");

            migrationBuilder.DropTable(
                name: "banco");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
