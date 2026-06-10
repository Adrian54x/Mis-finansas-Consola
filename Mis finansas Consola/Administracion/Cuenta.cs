using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_finansas_Consola
{
    internal class Cuenta
    {
        private DateTime fecha;
        private decimal cantidad;
        private string motivo;
        private string tipo;

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
            set => motivo = (value.Length > 4) ? value : throw new ArgumentException("Ingreso de motivo no inválido!"); 
        }

        public string Tipo 
        { 
            get => tipo; 
            set => tipo = (value == "Trabajo" || value == "Extra" || value == "otro") ? value : throw new ArgumentException("Tipo de ingreso no valido!"); 
        }

        public Cuenta(DateTime fecha, decimal cantidad, string motivo, string tipo)
        {
            Fecha = fecha;
            Cantidad = cantidad;
            Motivo = motivo;
            Tipo = tipo;
        }
    }
}
