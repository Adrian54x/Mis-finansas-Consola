using Mis_finansas_Consola.General;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mis_finansas_Consola
{
    internal class Program
    {
        public static Funciones funciones = new Funciones();
        public static Menus menus = new Menus();
        public static DatosGlobales datosGlobales = new DatosGlobales();
        static void Main(string[] args)
        {
            try
            {
                bool menuPrincipal = true;
                uint menu, subMenu;
                do
                {
                    Console.Clear();
                    menus.MenuPrincipal();
                    menu = funciones.ValidarEnterosPositivos();
                    Console.Clear();
                    switch (menu)
                    {
                        case 0:
                            Console.CursorVisible = false;
                            funciones.EscribirTexto(ConsoleColor.DarkRed, "Saliendo",false, 50,12);
                            funciones.EscribirTexto(ConsoleColor.DarkRed, ".", false, Console.CursorLeft, 12);
                            Thread.Sleep(200);                                       
                            funciones.EscribirTexto(ConsoleColor.DarkRed, ".", false, Console.CursorLeft, 12);
                            Thread.Sleep(200); 
                            funciones.EscribirTexto(ConsoleColor.DarkRed, ".", false, Console.CursorLeft, 12);
                            Thread.Sleep(200);
                            menuPrincipal = false;
                            break;

                        case 1:
                            menus.MenuFinanzas();
                            break;

                        case 2:
                        case 3:
                        default:
                            break;
                    }
                } while (menuPrincipal);
            } 
            catch (Exception ex)
            {
                funciones.EscribirTexto(ConsoleColor.Red, $"Ocurrio un error!:", true, 45, Console.CursorTop+1);
                funciones.EscribirTexto(ConsoleColor.DarkGray, ex.Message, true, 45, Console.CursorTop);
            }
        }
    }
}
