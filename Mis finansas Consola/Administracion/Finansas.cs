using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_finansas_Consola
{
    internal class Finansas
    {
        private string conexion = "Data Source = Finansas.db";
        private string sql;

        // Crear Tablas
        public void CrearTablas()
        {
            using (SqliteConnection ct = new SqliteConnection(conexion))
            {
                ct.Open();
                sql = @"CREATE TABLE IF NOT EXISTS  Ingresos(Codigo TEXT PRIMARY KEY, Fecha TEXT NOT NULL, Cantidad REAL NOT NULL, 
                        Motivo TEXT NOT NULL, Tipo TEXT NOT NULL);";
                using (SqliteCommand crear = new SqliteCommand(sql, ct))
                {
                    crear.ExecuteNonQuery();
                }

                sql = @"CREATE TABLE IF NOT EXISTS  Egresos(Codigo TEXT PRIMARY KEY, Fecha TEXT NOT NULL, Cantidad REAL NOT NULL, 
                        Motivo TEXT NOT NULL, Tipo TEXT NOT NULL);";
                using (SqliteCommand crear = new SqliteCommand(sql, ct))
                {
                    crear.ExecuteNonQuery();
                }

                sql = @"CREATE TABLE IF NOT EXISTS  Deseos(Codigo TEXT PRIMARY KEY, Fecha TEXT NOT NULL, Nombre TEXT NOT NULL, CantidadInicial REAL NOT NULL, 
                        CantidadMaxima REAL NOT NULL, Motivo TEXT NOT NULL, Tipo TEXT NOT NULL, Pioridad TEXT NOT NULL);";

                using (SqliteCommand crear = new SqliteCommand(sql, ct))
                {
                    crear.ExecuteNonQuery();
                }
            }
        }
    }
}
