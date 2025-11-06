using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MisionApagarLuces : MisionBase
    {
        public MisionApagarLuces() : base("Apaga las luces", "Asegurate de apagar las luces cuando no las nececites ", 5)
        {

        }

        public override string CompletarMision()
        {
            return$"¡Buena accion! Has completado: {Nombre}. Sumaste {Puntos} puntos.";
        }
    }
}
