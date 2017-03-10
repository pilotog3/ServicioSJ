using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Piloxy.ListaEspera
{
    public partial class PanelBarraCargando : Form
    {
        public PanelBarraCargando()
        {
            InitializeComponent();
        }

        public void SetUndefined()
        {
            barraProgreso.Style = ProgressBarStyle.Marquee;
            barraProgreso.Value = 0;
            barraProgreso.MarqueeAnimationSpeed = 50;
            label1.Text = "Cargando...";
        }

        public void SetBlocks()
        {
            barraProgreso.Style = ProgressBarStyle.Blocks;
        }

        public void SetValue(int value)
        {
            SetBlocks();
            if (value < 0 && value > 100)
                return;

            barraProgreso.Value = value;

            label1.Text = value.ToString()+ " %";
        }
    }
}
