using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HistorialMision
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdMision { get; set; }
        public DateTime FechaComplecion { get; set; }

        public HistorialMision() { }

        public HistorialMision(int id, int idUsuario, int idMision, DateTime fechaComplecion)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdMision = idMision;
            FechaComplecion = fechaComplecion;
        }


    }
}
