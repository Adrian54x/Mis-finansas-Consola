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
        static void Main(string[] args)
        {
            bool menuPrincipal = true;
            do
            {
                try
                {

                    uint menu;
                    int subMenu;
                    Console.Clear();
                    menus.MenuPrincipal();
                    menu = funciones.ValidarEnterosPositivos(Console.CursorLeft, Console.CursorTop);
                    Console.Clear();
                    switch (menu)
                    {
                        case 0:
                            Console.CursorVisible = false;
                            funciones.EscribirTexto(ConsoleColor.DarkRed, "Saliendo", false, 50, 12);
                            funciones.EscribirTexto(ConsoleColor.DarkRed, ".", false, Console.CursorLeft, 12);
                            Thread.Sleep(200);
                            funciones.EscribirTexto(ConsoleColor.DarkRed, ".", false, Console.CursorLeft, 12);
                            Thread.Sleep(200);
                            funciones.EscribirTexto(ConsoleColor.DarkRed, ".", false, Console.CursorLeft, 12);
                            Thread.Sleep(200);
                            menuPrincipal = false;
                            break;

                        case 1:
                            do
                            {
                                Console.Clear();
                                menus.MenuFinanzas();
                                subMenu = funciones.Rango(0, 3, Console.CursorLeft, Console.CursorTop, 43);
                                if (subMenu == 0)
                                {
                                    funciones.Regresar();
                                    break;
                                }
                                Console.Clear();
                                string opcion = (subMenu == 1) ? DatosGlobales.Categoria[0] : (subMenu == 2) ? DatosGlobales.Categoria[1] : (subMenu == 3) ? DatosGlobales.Categoria[2] : "Opción no válida";
                                funciones.AgregarFinanza(opcion);
                            } while (true);
                            break;

                        case 2:
                            menus.MenuFinanzas();
                            break;

                        case 3:
                            break;
                        case 4:
                        default:
                            funciones.OpcionNoValida();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    funciones.EscribirTexto(ConsoleColor.Red, $"Ocurrio un error!:", true, 45, Console.CursorTop + 1);
                    funciones.EscribirTexto(ConsoleColor.DarkGray, ex.Message, true, 45, Console.CursorTop);
                }
            } while (menuPrincipal);
        }
    }
}
