using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_finansas_Consola.General
{
    internal class Menus
    {
        private Funciones f = new Funciones();
        public void MenuPrincipal()
        {
            f.EscribirTexto(ConsoleColor.Yellow, "==== Biebenido a Administrar mis Finansas ===", true, 40, 4);
            f.EscribirTexto(ConsoleColor.Cyan, "1. Finanzas.", true, 40, 6);
            f.EscribirTexto(ConsoleColor.Blue, "2. Presupuestos.", true, 69, 6);
            f.EscribirTexto(ConsoleColor.DarkBlue, "3. Herramientas.", true, 40, 8);
            f.EscribirTexto(ConsoleColor.Red, "0. Salir.", true, 69, 8);
            f.EscribirTexto(ConsoleColor.Green, "Seleccione una opción:", false, 50, 10);
        }

        public void MenuFinanzas()
        {
            f.EscribirTexto(ConsoleColor.Yellow, "==== Finanzas ===", true, 50, 6);
            f.EscribirTexto(ConsoleColor.DarkCyan, "1. Agregar Ingresos.", true, 50, 8);
            f.EscribirTexto(ConsoleColor.DarkCyan, "2. Agregar Egresos.", true, 50, 10);
            f.EscribirTexto(ConsoleColor.DarkCyan, "3. Agregar Deseos.", true, 50, 12);
            f.EscribirTexto(ConsoleColor.Red, "0. Regresar.", true, 50, 14);
            f.EscribirTexto(ConsoleColor.Green, "Seleccione una opción:", false, 50, 16);
        }
    }
}
