using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mision
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Puntos { get; set; }

        public Mision() { }

        public Mision(int id, string nombre, string descripcion, int puntos)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Puntos = puntos;
        }
    }
}
