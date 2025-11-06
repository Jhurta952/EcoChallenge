using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class MisionBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Puntos { get; set; }

        public MisionBase(string nombre, string descripcion, int puntos)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Puntos = puntos;
        }

        public abstract string CompletarMision();

    }
}
