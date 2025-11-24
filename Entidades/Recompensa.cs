using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Recompensa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int PuntosRequeridos { get; set; }

        public Recompensa() {}

        public Recompensa(int id, string nombre, string descripcion, int puntosRequeridos)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            PuntosRequeridos = puntosRequeridos;
        }
    }
}
