using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MisionReciclaje : MisionBase
    {
        public MisionReciclaje() : base("Reciclaje Responsabel mi papa ", " separa correctamente los residuos del hogar", 10)
        {

        }

        public override string CompletarMision()
        {
            return $"!Has completado la mision: {Nombre}! Ganaste {Puntos} puntos";
        }
    }
}
