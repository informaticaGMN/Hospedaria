﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospedaria.fdrQuartos
{
    public partial class frmUnidadesmain : Form
    {
        public frmUnidadesmain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fdrQuartos.frmReservas frmReservas = new frmReservas();
            frmReservas.ShowDialog();
        }
    }
}