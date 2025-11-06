using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  static class MisionFactory
    {
        public static MisionBase CrearMision(string tipo)
        {
            switch (tipo)
            {
                case "Reciclaje":
                    return new MisionReciclaje();
               case "Ahorro de agua":
                    return new MisionAhorroAgua();
                case "Apagar luces":
                    return new MisionApagarLuces();
                default:
                    return null;
            }
        }
    }
}
