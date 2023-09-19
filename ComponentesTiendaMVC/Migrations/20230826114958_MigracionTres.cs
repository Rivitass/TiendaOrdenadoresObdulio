using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComponentesTiendaMVC.Migrations
{
    /// <inheritdoc />
    public partial class MigracionTres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NumeroSerie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Grados = table.Column<int>(type: "int", nullable: false),
                    Almacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoComponente = table.Column<int>(type: "int", nullable: false),
                    OrdenadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componente_Ordenadores_OrdenadorId",
                        column: x => x.OrdenadorId,
                        principalTable: "Ordenadores",
                        principalColumn: "IdOrdenador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ordenadores",
                columns: new[] { "IdOrdenador", "DescripcionOrdenador" },
                values: new object[,]
                {
                    { 1, "Almacen" },
                    { 2, "Ordenador de Maria" },
                    { 3, "Ordenador de Paco" }
                });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "IdOrdenador", "Almacenamiento", "Cores", "DescripcionOrdenador", "Grados", "NumeroSerie", "OrdenadorId", "Precio", "TipoComponente" },
                values: new object[,]
                {
                    { 1, "0", 9, "Procesador Intel i7", 10, "789_XCS", 1, 134.0, 1 },
                    { 2, "0", 10, "Procesador Intel i7", 12, "789_XCD", 2, 138.0, 1 },
                    { 3, "512", 0, "Banco de memoria SDRAM", 10, "879FH", 1, 100.0, 2 },
                    { 4, "1024", 0, "Banco de memoria SDRAM", 15, "879FH_L", 2, 125.0, 2 },
                    { 5, "500000", 0, "Disco Duro Scan Disk", 10, "789_XX", 1, 50.0, 3 },
                    { 6, "1000000", 0, "Disco Duro Scan Disk", 29, "789_XX_2", 2, 90.0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componente_OrdenadorId",
                table: "Componente",
                column: "OrdenadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Ordenadores");
        }
    }
}
