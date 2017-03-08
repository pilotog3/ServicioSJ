using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Models.Helpers
{
    class ListaEsperaHelper
    {
        public static string GetNombreCausa(int? numeroCausa)
        {
            switch (numeroCausa)
            {
                case 1: return "Operado";
                case 2: return "";
                case 5: return "Rechaza Cirugia";
                case null: return "Sin Causa";
                default: return "Sin Causa";
            }
        }
    }
}
