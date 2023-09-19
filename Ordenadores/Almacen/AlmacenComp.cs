using Ordenadores.Componentes;
using Ordenadores.Guardadores;
using Ordenadores.Memorizadores;
using Ordenadores.Procesadores;

namespace Ordenadores.Almacen
{
    public class AlmacenComp
    {
#pragma warning disable S1104 
        public Dictionary<string, Componente> componentes = new Dictionary<string, Componente>
        {
            {"789-XCS", new Procesable("Procesador Intel i7", "789-XCS", 134,  9, 10,1) },
            {"789-XCD" , new Procesable("Procesador Intel i7", "789-XCD", 138, 10, 12,1)},
            {"789-XCT" , new Procesable("Procesador Intel i7", "789-XCT", 138, 11, 22,2) },
            {"879FH" , new Memorizable("Banco de Memoria SDRAM", "879FH", 100,"512 MB",10,2 )},
            {"879FH-L" , new Memorizable("Banco de Memoria SDRAM", "879FH-L", 125,"1 Gb" , 15, 1)},
            {"879FH-T" , new Memorizable("Banco de Memoria SDRAM", "879FH-T", 150,"2 Gb" , 24, 1)},
            {"789-XX" , new Guardable("DiscoDuro SanDisk", "789-XX", 50,"500 Gb" , 10, 1)},
            {"789-XX-2" , new Guardable("DiscoDuro SanDisk", "789-XX-2", 90,"1 Tb" ,29 , 2)},
            {"789-XX-3" , new Guardable("DiscoDuro SanDisk", "789-XX-3", 128, "2 Tb",39 , 1)},
            {"797-X" , new Procesable("Procesador Ryzen AMD", "797-X", 78, 10, 30,1)},
            {"797-X2" , new Procesable("Procesador Ryzen AMD", "797-X2", 178, 29, 30,2)},
            {"797-X3" , new Procesable("Procesador Ryzen AMD", "797-X3", 278,34, 60,1)},
            {"788-fg" , new Guardable("Disco Mecánico Patatin", "788-fg", 37, "250 Mb", 35, 1)},
            {"788-fg-2" , new Guardable("Disco Mecánico Patatin", "788-fg-2", 67, "250 Mb",35 , 1)},
            {"788-fg-3" , new Guardable("Disco Mecánico Patatin", "788-fg-3", 97, "250 Mb", 35, 1)},
            {"1789-XCS" , new Guardable("Disco Externo Sam", "1789-XCS", 134, "9 Tb", 10, 1)},
            {"1789-XCD" , new Guardable("Disco Externo Sam", "1789-XCD", 138, "10 Tb",12 , 1)},
            {"1789-XCT" , new Guardable("Disco Externo Sam", "1789-XCT", 140, "11 Tb",22 , 0)}
        };
#pragma warning restore S1104 
        public Componente GetCompAlma(string claveComponente)
        {
            if (componentes.ContainsKey(claveComponente) && componentes[claveComponente].Cantidad >= 0)
            {
                componentes[claveComponente].Cantidad--;
                return componentes[claveComponente];
            }
            else
            {
                return new SinStock();
            }
        }

    }
    public class SinStock : Componente
    {
        public SinStock()
        {
        }
    }

}
