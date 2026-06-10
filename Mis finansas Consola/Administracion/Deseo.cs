using Mis_finansas_Consola.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_finansas_Consola
{
    internal class Deseo : Cuenta
    {
        private string nombre;
        private decimal montoMaximo;
        private bool Pioridad;

        public string Nombre 
        { 
            get => nombre;
            set
            {
                bool val = true;
                foreach (char i in value)
                {
                    if(!DatosGlobales.Letras.Contains(i))
                    {
                        val = false;
                        break;
                    }
                }
                nombre = (value.Length >= 3 && val) ? value : throw new ArgumentException("El nombre ingresado no Valido!");
            }
        }
      

        public decimal MontoMaximo 
        { 
            get => montoMaximo; 
            set => montoMaximo = (value > Cantidad && decimal.TryParse(value.ToString(), out decimal x)) ? value : throw new ArgumentException("El monto máximo no es mayor que la cantidad inicial!"); 
        }

        public bool Pioridad1 
        { 
            get => Pioridad; 
            set => Pioridad = value; 
        }

        public Deseo(DateTime fecha, decimal cantidad, string motivo, string tipo, string nombre, decimal montoMaximo, bool pioridad) : base(fecha, cantidad, motivo, tipo)
        {
            Nombre = nombre;
            MontoMaximo = montoMaximo;
            Pioridad = pioridad;
        }
    }
}
