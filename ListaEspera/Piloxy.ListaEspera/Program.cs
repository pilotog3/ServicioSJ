﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Piloxy.ListaEspera
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Test.TestClass.Test();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new VentanaPrincipal());
        }
    }
}
