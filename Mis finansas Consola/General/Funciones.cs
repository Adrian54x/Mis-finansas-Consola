using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mis_finansas_Consola.General
{
    internal class Funciones
    {
        //Funciones Basicas

        public void PocicionAnterior(int pocicionX, int pocicionY)
        {
            Console.SetCursorPosition(pocicionX, pocicionY);
            Console.Write("                                                                  ");
        }

        public void OpcionNoValida()
        {
            Console.Clear();
            Console.CursorVisible = false;
            EscribirTexto(ConsoleColor.DarkRed, "opcion no valida!", false, 50, 12);
            EscribirTexto(ConsoleColor.DarkGreen, "---", false, Console.CursorLeft, 12);
            Thread.Sleep(200);
            EscribirTexto(ConsoleColor.DarkGreen, "--->", false, Console.CursorLeft, 12);
            Thread.Sleep(200);
            EscribirTexto(ConsoleColor.Green, "Intente otra vez", false, Console.CursorLeft, 12);
            Thread.Sleep(200);
            Console.CursorVisible = true;
        }

        public void Regresar()
        {
            Console.Clear();
            Console.CursorVisible = false;
            EscribirTexto(ConsoleColor.DarkRed, "Regresando", false, 50, 12);
            EscribirTexto(ConsoleColor.DarkRed, ".", false, Console.CursorLeft, 12);
            Thread.Sleep(200);
            EscribirTexto(ConsoleColor.DarkRed, ".", false, Console.CursorLeft, 12);
            Thread.Sleep(200);
            EscribirTexto(ConsoleColor.DarkRed, ".", false, Console.CursorLeft, 12);
            Thread.Sleep(200);
            Console.CursorVisible = true;
        }

        public int Rango(int inicio, int fin, int pocicionX, int pocicionY, int pocicionE)
        {
            int numero;
            while(true)
            {
                PocicionAnterior(pocicionX, pocicionY);
                Console.SetCursorPosition(pocicionX, pocicionY);
                if (int.TryParse(Console.ReadLine(), out numero) && numero >= inicio && numero <= fin)
                    return numero;
                Error(pocicionE, Console.CursorTop + 1);
            }
        }

        public string ValidarTexto(int cantidadMinimaCaracters, int pocicionX, int pocicionY)
        {
            while (true)
            {
                PocicionAnterior(pocicionX, pocicionY);
                Console.SetCursorPosition(pocicionX, pocicionY);
                string texto = Console.ReadLine();
                if (texto.Length >= cantidadMinimaCaracters)
                    return texto;
                Error(Console.CursorLeft, Console.CursorTop + 1);
            }
        }

        public bool SIoNO(int pocicionX, int pocicionY)
        {
            string SioNo;
            bool SIoNO = false;
            while (true)
            {
                PocicionAnterior(pocicionX, pocicionY);
                Console.SetCursorPosition(pocicionX, pocicionY);
                SioNo = Console.ReadLine();
                if (string.Equals(SioNo, "si", StringComparison.OrdinalIgnoreCase) || string.Equals(SioNo, "no", StringComparison.OrdinalIgnoreCase))
                {
                    return SIoNO;
                }
                Error(Console.CursorLeft, Console.CursorTop + 1);
            }
        }

        public void Error(int pocicionX, int pocicionY)
        {
            Console.CursorVisible = false;
            EscribirTexto(ConsoleColor.Red, "Error de ingreso!", false, pocicionX, pocicionY);
            Thread.Sleep(200);
            EscribirTexto(ConsoleColor.DarkGreen, "---", false, Console.CursorLeft, Console.CursorTop);
            Thread.Sleep(300);
            EscribirTexto(ConsoleColor.DarkGreen, "--->", false, Console.CursorLeft, Console.CursorTop);
            Thread.Sleep(300);
            EscribirTexto(ConsoleColor.Green, "Intente otra vez", false, Console.CursorLeft, Console.CursorTop);
            Thread.Sleep(500);
            Console.SetCursorPosition(pocicionX, pocicionY);
            Console.WriteLine("                                                              ");
            Console.CursorVisible = true;

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

        public uint ValidarEnterosPositivos(int pocicionX, int pocicionY)
        {
            uint entero;
            while (true)
            {
                PocicionAnterior(pocicionX, pocicionY);
                Console.SetCursorPosition(pocicionX, pocicionY);
                if (uint.TryParse(Console.ReadLine(), out entero))
                    return entero;
                Error(45, Console.CursorTop + 1);
            }
        }


        // Opciones de agregar

        public string GeneradorCodigos(int codigoActual)
        {
            return "0" + (codigoActual + 1).ToString();
        }

        public DateTime ValidarFecha(int pocicionX, int pocicionY)
        {
            DateTime fecha;
            while(true)
            {
                PocicionAnterior(pocicionX, pocicionY);
                Console.SetCursorPosition(pocicionX, pocicionY);
                if(DateTime.TryParse(Console.ReadLine(), out fecha) && fecha.Year > 2025 && fecha.Date <= DateTime.Today)
                    return fecha;
                Error(Console.CursorLeft, Console.CursorTop + 1);
            }
        }

        public decimal ValidarCantidad(int pocicionX, int pocicionY)
        {
            decimal cantidad;
            while (true)
            {
                PocicionAnterior(pocicionX, pocicionY);
                Console.SetCursorPosition(pocicionX, pocicionY);
                if(decimal.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0.00m)
                    return cantidad;
                Error(Console.CursorLeft, Console.CursorTop + 1);
            }
        }

        public Cuenta AgregarFinanza(string categoria)
        {

            if (!DatosGlobales.Categoria.Contains(categoria))
            {
                Error(Console.CursorLeft, Console.CursorTop + 1);
                return null;
            }
            else
            {
                EscribirTexto(ConsoleColor.Yellow, $"=== Agregar {categoria} ===", false, 50, 0);
                string text;
                string codigo = char.ToString(categoria[0]) + GeneradorCodigos(0);
                EscribirTexto(ConsoleColor.DarkGreen, "Codigo:", false, 55, 2);
                Console.Write(codigo);

                EscribirTexto(ConsoleColor.DarkGreen, "Fecha:", false, 30, 4);
                DateTime fecha = (categoria == DatosGlobales.Categoria[2]) ? DateTime.Today : ValidarFecha(Console.CursorLeft, Console.CursorTop);
                if (categoria == DatosGlobales.Categoria[2])
                    Console.Write(fecha.ToString("d"));

                if (categoria == DatosGlobales.Categoria[2])
                    EscribirTexto(ConsoleColor.DarkGreen, "Nombre:", false, 75, 4);
                string nombre = (categoria == DatosGlobales.Categoria[2]) ? ValidarTexto(3, Console.CursorLeft, Console.CursorTop) : nombre = null;

                text = (categoria == DatosGlobales.Categoria[2]) ? "Monto Inicial:Q" : "Monto:Q";
                EscribirTexto(ConsoleColor.DarkGreen, text, false, 30, 6);
                decimal cantidad = ValidarCantidad(Console.CursorLeft, Console.CursorTop);

                if (categoria == DatosGlobales.Categoria[2])   
                    EscribirTexto(ConsoleColor.DarkGreen, "Monto Maximo:Q", false, 75, 6);
                decimal montoMaximo = (categoria == DatosGlobales.Categoria[2]) ? ValidarCantidad(Console.CursorLeft, Console.CursorTop) : 0m;

                if (categoria == DatosGlobales.Categoria[0] || categoria == DatosGlobales.Categoria[1])
                    EscribirTexto(ConsoleColor.DarkGreen, $"Motivo del {categoria}:", true, 30, 8);
                string motivo = (categoria == DatosGlobales.Categoria[0] || categoria == DatosGlobales.Categoria[1]) ? ValidarTexto(4, 30, Console.CursorTop) : null;

                if (categoria == DatosGlobales.Categoria[2])
                    EscribirTexto(ConsoleColor.DarkGreen, "Pioridad(Si/No):", false, 30, 8);
                bool Pioridad = (categoria == DatosGlobales.Categoria[2]) ? SIoNO(Console.CursorLeft, Console.CursorTop) : false;

                if (categoria == DatosGlobales.Categoria[0] || categoria == DatosGlobales.Categoria[1])
                {
                    EscribirTexto(ConsoleColor.DarkGreen, $"Tipo de {categoria}:", false, 75, 6);
                    EscribirTexto(ConsoleColor.DarkGreen, "(1.Unico / 2.Semanal / 3.Mes / 4.Año:):", false, 75, 7);
                }
                int tipo = (categoria == DatosGlobales.Categoria[0] || categoria == DatosGlobales.Categoria[1]) ? Rango(1,4, Console.CursorLeft, Console.CursorTop, 43) : 0;

                return (categoria == DatosGlobales.Categoria[0] || categoria == DatosGlobales.Categoria[1]) ? new Cuenta(codigo, fecha, cantidad, motivo, DatosGlobales.tipo[tipo-1]) : new Deseo(codigo, fecha, cantidad, motivo, DatosGlobales.tipo[tipo], nombre, montoMaximo, Pioridad);
            }
        }

        

    }
}
