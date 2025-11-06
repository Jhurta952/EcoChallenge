using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MisionAhorroAgua : MisionBase
    {
        public MisionAhorroAgua() : base("Ahorro de agua", "Reduce el tiempo de ducha y evita desperdicio", 15)
        {

        }

        public override string CompletarMision()
        {
            return$"¡Exelente! Has completado la misión: {Nombre}. Has ganado {Puntos} puntos";
        }
    }
}
