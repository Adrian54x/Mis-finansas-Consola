using Mis_finansas_Consola.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_finansas_Consola
{
    internal class Cuenta
    {
        private string codigo;
        private DateTime fecha;
        private decimal cantidad;
        private string motivo;
        private string tipo;

        public string Codigo
        {
            get => codigo;
            set => codigo = (value.StartsWith("I") || value.StartsWith("E") || value.StartsWith("D")) ? value : throw new ArgumentException("Ingreso de código no válido!");
        }

        public DateTime Fecha 
        { 
            get => fecha; 
            set => fecha = (value.Year > 2025 && DateTime.TryParse(value.ToString(), out DateTime x)) ? value : throw new ArgumentException("Ingreso de fecha no inválida!"); 
        }

        public decimal Cantidad 
        { 
            get => cantidad; 
            set => cantidad = (value > 0.00m && decimal.TryParse(value.ToString(), out decimal x)) ? value : throw new ArgumentException("Ingreso de cantidad no inválida!"); 
        }

        public string Motivo 
        { 
            get => motivo; 
            set => motivo = value; 
        }

        public string Tipo 
        { 
            get => tipo; 
            set => tipo = (value == DatosGlobales.Categoria[0] || value == DatosGlobales.Categoria[1] || value == DatosGlobales.Categoria[2] ) ? value : throw new ArgumentException("Tipo de ingreso no valido!"); 
        }

        public Cuenta(string codigo, DateTime fecha, decimal cantidad, string motivo, string tipo)
        {
            Codigo = codigo;
            Fecha = fecha;
            Cantidad = cantidad;
            Motivo = motivo;
            Tipo = tipo;
        }
    }
}
