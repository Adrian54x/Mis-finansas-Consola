using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_finansas_Consola.General
{
    internal class Funciones
    {
        private DatosGlobales d = new DatosGlobales();
        //Funciones Basicas

        public void Error(int pocicionX, int pocicionY)
        {
            EscribirTexto(ConsoleColor.Red, "Error de ingreso!", true, pocicionX, pocicionY);
        }

        public void EscribirTexto(ConsoleColor color, string texto, bool Line, int pocicionX, int pocicionY)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(pocicionX, pocicionY);
            Console.ForegroundColor = color;
            if (Line)
                Console.WriteLine(texto);
            else
                Console.Write(texto);
            Console.ResetColor();
            Console.CursorVisible = true;
        }

        public uint ValidarEnterosPositivos()
        {
            uint entero;
            while (!uint.TryParse(Console.ReadLine(), out entero))
            {    
                Error(Console.CursorLeft, Console.CursorTop+1);
            }
            return entero;
        }


        // Opciones de agregar

        public Cuenta AgregarFinanza(string tipo)
        {

            return () ? new Cuenta() : new Deseo();
        }
}
