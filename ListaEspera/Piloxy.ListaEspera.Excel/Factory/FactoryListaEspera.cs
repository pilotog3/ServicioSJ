using Piloxy.ListaEspera.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Application.Factory
{
    static class FactoryListaEspera
    {
        public static ILeible<T> ObtenerLeible<T>(Enums.TipoArchivoEnum tipoArchivo) where T:class
        {
            switch (tipoArchivo)
            {
                case Enums.TipoArchivoEnum.ListaEspera: return (ILeible<T>)new Excel.ListaEspera();
                default: throw new Exception("No existe tipo de excel solicitado");
            }
        }

        public static IGuardable<T> ObtenerGuardable<T>(Enums.TipoArchivoEnum tipoArchivo) where T : class
        {
            switch (tipoArchivo)
            {
                case Enums.TipoArchivoEnum.ListaEspera: return (IGuardable<T>)new Excel.ListaEspera();
                default: throw new Exception("No existe tipo de excel solicitado");
            }
        }
    }
}
