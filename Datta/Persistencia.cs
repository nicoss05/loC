using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using System.ComponentModel.Composition;


namespace Datta
{
    [Export(typeof(IGrabador))]
    public class Persistencia : IGrabador
    {
        public bool Grabar (Estudiante estudiante)
        {
            try
            {
                estudiante.EstudianteId = new Random().Next(1000, 9999);
                System.IO.File.AppendAllLines("Data.csv",
              new List<string>
              {
                   string.Format("{0},{1},{2}"
                   ,estudiante.EstudianteId.ToString()
                   ,estudiante.Nombre
                   ,estudiante.Apellido )
              },
                Encoding.UTF8);
            }
            catch
            {
                return false;
            }
            return true;

        }
    }
}