﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospedaria.fdrVendas
{
    public partial class frmVendas : Form
    {
        public Form RefToMenu { get; set; }
        public frmVendas()
        {
            InitializeComponent();
        }

        private void frmVendas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RefToMenu.Show();
        }
    }
}
